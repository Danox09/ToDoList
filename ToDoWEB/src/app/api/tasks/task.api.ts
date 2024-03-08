import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CreateUpdateTaskDTO } from './task.dto';
import { Task } from 'src/app/api/tasks/task.model';

@Injectable({
  providedIn: 'root'
})
export class TaskApi {
  API: string='https://localhost:7158/api/persons/'

  constructor(private clienteHttp:HttpClient) { };

  GetTasks(id:string): Observable<any>{
    return this.clienteHttp.get(this.API+ id + "/tasks");
  } 

  CreateTask(task: Task, userId: string): Observable<any> {
    let data = new CreateUpdateTaskDTO(task);
    console.log(userId);

    return this.clienteHttp.post(this.API+ userId + "/tasks", data);
  }
  
  UpdateTask(taskToUpdate: Task, userId: string, taskId:string) : Observable<any> {
    let data = new CreateUpdateTaskDTO(taskToUpdate)
    return this.clienteHttp.put(`${this.API}${userId}/tasks/${taskId}`, data);
  }
  }
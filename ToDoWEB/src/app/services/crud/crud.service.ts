import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from 'src/app/api/users/user.model';
import { CreateUpdateTaskDTO } from '../../api/tasks/task.dto';
import { Task } from 'src/app/api/tasks/task.model';

@Injectable({
  providedIn: 'root'
})
export class CRUDService {
  API: string='https://localhost:7158/api/persons/'

  constructor(private clienteHttp:HttpClient) { };

  GetUsers(): Observable<any> {
    return this.clienteHttp.get(this.API);
  }

  GetUserById(id:string): Observable<any>{
    return this.clienteHttp.get(this.API +id);
  }

  createUser(user: User): Observable<any> {
    return this.clienteHttp.post(this.API, user);
  }



  updateUser(userToUpdate: User, userid:string) : Observable<any>{
    const url = `${this.API}${userid}`;
    return this.clienteHttp.put<User>(url, userToUpdate);
  }

  deleteUser(userId: string): Observable<any> {
    return this.clienteHttp.delete(this.API +userId);
  }

  GetTasks(id:string): Observable<any>{
    return this.clienteHttp.get(this.API+ id + "/tasks");
  } 

  createTask(task: Task, userId: string): Observable<any> {
    let data = new CreateUpdateTaskDTO(task);
    console.log(userId);

    return this.clienteHttp.post(this.API+ userId + "/tasks", data);
  }
  
  updateTask(taskToUpdate: Task, userId: string, taskId:string) : Observable<any> {
    const url = `${this.API}${userId}/tasks/${taskId}`;
    let data = new CreateUpdateTaskDTO(taskToUpdate)
    return this.clienteHttp.put(url, data);
  }








}

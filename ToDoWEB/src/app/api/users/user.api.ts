import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from 'src/app/api/users/user.model';

@Injectable({
  providedIn: 'root'
})
export class UserApi {
  API: string='https://localhost:7158/api/persons/'

  constructor(private clienteHttp:HttpClient) { };
  GetUsers(): Observable<any> {
    return this.clienteHttp.get(this.API);
  }

  GetUserById(id:string): Observable<any>{
    return this.clienteHttp.get(this.API +id);
  }

  CreateUser(user: User): Observable<any> {
    return this.clienteHttp.post(this.API, user);
  }

  UpdateUser(userToUpdate: User, userid:string) : Observable<any>{
    return this.clienteHttp.put<User>(`${this.API}${userid}`, userToUpdate);
  }

  DeleteUser(userId: string): Observable<any> {
    return this.clienteHttp.delete(this.API +userId);
  }
}
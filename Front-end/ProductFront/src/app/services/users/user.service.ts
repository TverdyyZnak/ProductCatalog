import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserEnter } from '../../models/UserEnter';
import { User } from '../../models/User';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private readonly apiUrl = "/api/users"
  constructor(private http: HttpClient) { }

  login(login: string, password: string):Observable<string>{
    const body ={
      login: login,
      password: password
    }

    return this.http.post<string>(this.apiUrl+"/login", body, {withCredentials: true})
  }

  logout():Observable<void>{
    return this.http.post<void>(this.apiUrl+"/logout", null)
  }

  regNewUser(login: string, password: string, role: string):Observable<void>{
    const body = {
      login: login,
      hashPass: password,
      isBlocked: false,
      userRole: role
    }

    return this.http.post<void>(this.apiUrl+"/registration", body)
  }

  getAllUsers():Observable<User[]>{
    return this.http.get<User[]>(this.apiUrl)
  }

  deleteUser(id: string):Observable<void>{
    const params = new HttpParams().set("id", id)
    return this.http.delete<void>(this.apiUrl, {params: params})
  }

  blockUser(id: string):Observable<void>{
    const params = new HttpParams().set("userId", id)
    return this.http.post<void>(this.apiUrl+"/blocking", null,  {params: params})
  }

  unblockUser(id: string):Observable<void>{
    const params = new HttpParams().set("userId", id)
    return this.http.post<void>(this.apiUrl+"/unblocking", null,  {params: params})
  }

  passwodrChange(id: string, oldPass: string, newPass: string):Observable<void>{
    const params = new HttpParams().set("userId", id)
    params.set("oldPassword", oldPass)
    params.set("newPassword", newPass)

    const body = {
      userId: id,
      oldPassword: oldPass,
      newPassword: newPass
    }

    return this.http.put<void>(this.apiUrl, body)
  }
}

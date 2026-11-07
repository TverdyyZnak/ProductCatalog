import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserAction } from '../../models/UserAction';

@Injectable({
  providedIn: 'root'
})
export class UserActionService {

  private readonly apiUrl = "/api/actions"
  constructor(private http: HttpClient) { }

  getUserActions():Observable<UserAction[]>{
    return this.http.get<UserAction[]>(this.apiUrl)
  }
}

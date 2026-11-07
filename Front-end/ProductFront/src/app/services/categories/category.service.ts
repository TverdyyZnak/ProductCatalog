import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Category } from '../../models/Category';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  private readonly apiUrl = '/api/categories'
  
  constructor(private http: HttpClient) { }

  getAllCategories():Observable<Category[]>{
    return this.http.get<Category[]>(this.apiUrl)
  }

  createCategory(name: string):Observable<void>{
    const params = new HttpParams().set('name', name);
    return this.http.post<void>(this.apiUrl, null, {
      params: params
    })
  }
}

import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Product } from '../../models/Product';
import { Filter } from '../../models/Filtre';
import { newProduct } from '../../components/main-page/main-page.component';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private readonly apiUrl = '/api/products'
  constructor(private http: HttpClient) { }

  getProducts(filter?: Filter): Observable<Product[]> {

    let params = new HttpParams();

    if (filter) {
      if (filter.SearchName) {
        params = params.set('SearchName', filter.SearchName);
      }
      if (filter.MinPrice !== undefined) {
        params = params.set('MinPrice', filter.MinPrice.toString());
      }
      if (filter.MaxPrice !== undefined) {
        params = params.set('MaxPrice', filter.MaxPrice.toString());
      }
      if (filter.CategoryId) {
        params = params.set('CategoryId', filter.CategoryId);
      }
      if (filter.SortBy) {
        params = params.set('SortBy', filter.SortBy);
      }
    }

    return this.http.get<Product[]>(this.apiUrl, { params: params, withCredentials: true });
  }

  getProductById(id: string): Observable<Product[]> {
    return this.http.get<Product[]>(this.apiUrl + "/{id}")
  }

  updateProduct(id: string, product: Product): Observable<void> {
    const body = {
      name: product.name,
      description: product.description,
      price: product.price,
      mainNote: product.mainNote,
      subNote: product.subNote,
      categoryId: product.categoryId
    }

    return this.http.put<void>(`${this.apiUrl}/${id}`, body,
      {
        withCredentials: true
      })
  }

  deleteProduct(id: string): Observable<void> {
    return this.http.delete<void>(
      `${this.apiUrl}/${id}`,
      { withCredentials: true }
    );
  }

  createProduct(product: newProduct): Observable<void> {
    const body = {
      name: product.name,
      description: product.description,
      price: product.price,
      mainNote: product.mainNote,
      subNote: product.subNote,
      caregoryId: product.categoryId
    }

    return this.http.post<void>(this.apiUrl, body)
  }
}

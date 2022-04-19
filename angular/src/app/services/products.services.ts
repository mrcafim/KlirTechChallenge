import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Product } from '../models/product.model';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class ProductsService {

  private baseURL: string = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getProducts(): Observable<Product[]>{
    return this.http.get<Product[]>(`${this.baseURL}/product`);
  }

  getProduct(id: string): Observable<Product>{
    return this.http.get<Product>(`${this.baseURL}/product/`+ id);
  }
}

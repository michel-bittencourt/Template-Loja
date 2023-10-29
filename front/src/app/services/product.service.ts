import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Product } from '../models/product';

@Injectable()
export class ProductService {
  baseURL = 'https://localhost:7285/api/product';
  constructor(private http: HttpClient) {}

  public GetProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(`${this.baseURL}`);
  }

  public GetProductsById(productId: number): Observable<Product> {
    return this.http.get<Product>(`${this.baseURL}/${productId}`);
  }
}

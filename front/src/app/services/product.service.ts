import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Product } from '../models/product';

@Injectable()
export class ProductService {
  baseURL = 'https://localhost:7285/api';
  constructor(private http: HttpClient) {}

  public getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(`${this.baseURL}/product`);
  }

  public getProductsById(id: number): Observable<Product> {
    return this.http.get<Product>(`${this.baseURL}/${id}`);
  }
  public getProductsByInventory(id: number): Observable<Product[]> {
    return this.http.get<Product[]>(`${this.baseURL}/inventory/${id}`);
  }
}

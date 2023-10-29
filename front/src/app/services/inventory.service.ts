import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Inventory } from '../models/inventory';

@Injectable()
export class InventoryService {
  baseUrl = 'https://localhost:7285/api/inventory';
  constructor(private http: HttpClient) {}

  public GetInventories(): Observable<Inventory[]> {
    return this.http.get<Inventory[]>(`${this.baseUrl}`);
  }

  public GetInventoryById(inventoryId: number): Observable<Inventory> {
    return this.http.get<Inventory>(`${this.baseUrl}/${inventoryId}`);
  }
}

import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss'],
})
export class ProductComponent implements OnInit {
  public products: any;

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getProducts();
  }

  public getProducts(): void {
    this.http.get('https://localhost:7168/Product').subscribe(
      (Response) => (this.products = Response),
      (error) => console.log(error)
    );
  }
}

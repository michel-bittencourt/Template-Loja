import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss'],
})
export class ProductComponent implements OnInit {
  mostrarImagem: boolean = true;
  private _listFilter: string = '';
  public filteredProducts: any = [];

  public get listFilter(): string {
    return this._listFilter;
  }

  public set listFilter(value: string) {
    this._listFilter = value;
    this.filteredProducts = this.listFilter
      ? this.ProductsFilter(this.listFilter)
      : this.products;
  }

  ProductsFilter(filterBy: string): any {
    filterBy = filterBy.toLocaleLowerCase();
    return this.products.filter(
      (products: any) =>
        products.name.toLocaleLowerCase().indexOf(filterBy) !== -1 ||
        products.description.toLocaleLowerCase().indexOf(filterBy) !== -1
    );
  }

  isCollapsed = false;

  public products: any = [];

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.GetProducts();
  }

  ChangeImage() {
    this.mostrarImagem = !this.mostrarImagem;
  }

  public GetProducts(): void {
    this.http.get('https://localhost:7168/Product').subscribe(
      (Response) => {
        this.products = Response;
        this.filteredProducts = this.products;
      },
      (error) => console.log(error)
    );
  }
}

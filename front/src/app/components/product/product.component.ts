import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../services/product.service';
import { Product } from '../../models/product';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss'],
})
export class ProductComponent implements OnInit {
  public products: Product[] = [];
  public filteredProducts: any = [];

  mostrarImagem: boolean = true;
  private _listFilter: string = '';

  public get listFilter(): string {
    return this._listFilter;
  }

  public set listFilter(value: string) {
    this._listFilter = value;
    this.filteredProducts = this.listFilter
      ? this.ProductsFilter(this.listFilter)
      : this.products;
  }

  public ProductsFilter(filterBy: string): Product[] {
    filterBy = filterBy.toLocaleLowerCase();
    return this.products.filter(
      (products: any) =>
        products.name.toLocaleLowerCase().indexOf(filterBy) !== -1 ||
        products.description.toLocaleLowerCase().indexOf(filterBy) !== -1
    );
  }

  isCollapsed = false;

  constructor(private productService: ProductService) {}

  ngOnInit(): void {
    this.GetProducts();
  }

  ChangeImage() {
    this.mostrarImagem = !this.mostrarImagem;
  }

  public GetProducts(): void {
    this.productService.GetProducts().subscribe(
      (_products: Product[]) => {
        this.products = _products;
        this.filteredProducts = this.products;
      },
      (error) => console.log(error)
    );
  }
}

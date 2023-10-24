import { Product } from "./product";

export interface Inventory {
    Id: number;
    Name: string;
    Description?: string;

    ProductEntity: Product[];
}

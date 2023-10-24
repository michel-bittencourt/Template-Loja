import { Inventory } from "./inventory";

export interface Product {
  Id: number;
  Name: string;
  Description?: string;
  Dimension?: string;
  Material?: string;
  Available: boolean;
  UrlImagem?: string;

  InventoryId: number;
  InventoryEntity: Inventory[];
}

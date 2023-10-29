export interface Product {
  id: number;
  name: string;
  description?: string;
  dimensions?: string;
  material?: string;
  available: boolean;
  urlImagem?: string;

  inventoryId: number;
}

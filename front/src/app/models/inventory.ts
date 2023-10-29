import { Product } from './product';

export interface Inventory {
  id: number;
  name: string;
  entryDate: Date;
  exitDate?: Date;
  storageLocation?: string;
  additionalNotes?: string;

  products: Product[];
}

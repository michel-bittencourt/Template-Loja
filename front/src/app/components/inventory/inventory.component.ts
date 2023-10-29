import { Component, OnInit } from '@angular/core';
import { Inventory } from 'src/app/models/inventory';
import { InventoryService } from 'src/app/services/inventory.service';

@Component({
  selector: 'app-inventory',
  templateUrl: './inventory.component.html',
  styleUrls: ['./inventory.component.scss'],
})
export class InventoryComponent implements OnInit {
  inventories: Inventory[] = [];

  constructor(private inventoryService: InventoryService) {}

  ngOnInit(): void {
    this.GetInventories();
  }

  public GetInventories(): void {
    this.inventoryService
      .GetInventories()
      .subscribe((_inventories: Inventory[]) => {
        this.inventories = _inventories;
      });
  }
}

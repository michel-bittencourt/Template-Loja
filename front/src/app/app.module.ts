import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import {} from '@angular/animations';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProductComponent } from './components/product/product.component';
import { NavComponent } from './components/nav/nav.component';

import { CollapseModule } from 'ngx-bootstrap/collapse';
import { ProductService } from './services/product.service';
import { InventoryComponent } from './components/inventory/inventory.component';
import { InventoryService } from './services/inventory.service';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    ProductComponent,
    InventoryComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    CollapseModule.forRoot(),
    FormsModule,
  ],
  providers: [ProductService, InventoryService],
  bootstrap: [AppComponent],
})
export class AppModule {}

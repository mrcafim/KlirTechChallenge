import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { ShareModule } from '../shared/share.module';
import { ProductListComponent } from './product-list/product-list.component';
import { ProductComponent } from './product/product.component';
import { productRoutes } from './products.routes';

@NgModule({
  declarations: [ProductListComponent, ProductComponent],
  imports: [FormsModule, ShareModule, RouterModule.forChild(productRoutes)]
})
export class ProductsModule { }

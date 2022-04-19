import { Routes } from '@angular/router';
import { ProductListComponent } from './product-list/product-list.component';
import { ProductComponent } from './product/product.component';

export const productRoutes: Routes = [
    { path: '', component: ProductListComponent },
    { path: 'details/:id', component: ProductComponent }
];
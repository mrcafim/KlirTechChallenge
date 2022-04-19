import { NgModule } from "@angular/core";
import { CartService } from "./cart.services";
import { ProductsService } from './products.services';

@NgModule({
    providers: [
        CartService,
        ProductsService,
    ]
})
export class ServiceModule {}

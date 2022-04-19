import { NgModule } from "@angular/core";
import { ProductsService } from './products.services';

@NgModule({
    providers: [
        ProductsService,
    ]
})
export class ServiceModule {}

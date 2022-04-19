import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/models/product.model';
import { ProductsService } from '../../../services/products.services';
import { Router } from '@angular/router';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

  productsList: Product[] = [];
  pagination: number = 0;
  constructor(private productsService: ProductsService,
              private router: Router) { }

  ngOnInit() {
    this.fetchProducts();
  }  
  
  fetchProducts(): void {
    this.productsService.getProducts()
    .subscribe(products =>{
      console.log(products);
      this.productsList = products;
    });
  } 
  
  productDetail(product: string) {
      this.router.navigate(["/products/details", product]);
  };
}

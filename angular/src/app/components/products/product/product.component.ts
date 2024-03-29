import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from 'src/app/models/product.model';
import { CartService } from '../../../services/cart.services';
import { ProductsService } from '../../../services/products.services';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  productId: string;
  product: Product = null;
  quantity: number = 1;
  constructor(private productsService: ProductsService,
              private cartService: CartService,
              private router: Router,
              private route: ActivatedRoute) { }

  ngOnInit() {
    this.productId = this.route.snapshot.params['id'];
    this.productsService.getProduct(this.productId).subscribe(product => this.product = product );
    this.quantity = this.cartService.getProductCurrentQuantity(this.productId);
  }

  add(){
    this.cartService.add(this.productId, this.quantity);
    alert("Successfully added to your cart!")
  }

}

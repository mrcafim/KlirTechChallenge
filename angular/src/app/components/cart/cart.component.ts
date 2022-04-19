import { Component, OnInit } from '@angular/core';
import { Cart } from 'src/app/models/cart.model';
import { CartService } from '../../services/cart.services';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  cart: Cart = new Cart();
  isLoaded = false;
  constructor(private cartService: CartService) { }

  ngOnInit() {
    this.cart = this.cartService.getSessionCart();
    this.isLoaded = true;
  }

  cleanCart() {
    this.cartService.cleanCart();
    alert("All products removed successfully");
    this.isLoaded = false;
  }
}

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Cart, CartItems } from '../models/cart.model';

@Injectable({
  providedIn: 'root'
})

export class CartService {

  private baseURL: string = environment.apiUrl;
  storageKey: string = "Klir";
  cart: Cart = null;
  
  constructor(private http: HttpClient) { }

  getSessionCart() {
    this.cart = JSON.parse(localStorage.getItem(this.storageKey))
    return this.cart
  }

  getCart(){
    var cart = this.getSessionCart();
    this.http.get<Cart>(`${this.baseURL}/cart/`+ cart.id).subscribe(x =>{
      this.setShoppingCart(x);
    });
  }

  getProductCurrentQuantity(productId: string) : number{
    if(this.getSessionCart()){
      return this.cart.items.find(x => x.productId == productId) != null ? this.cart.items.find(x => x.productId == productId).quantity : 0;
    }
    return 0;
  }

  cleanCart() {
    localStorage.setItem(this.storageKey, null)
  }

  calculateCart(): Observable<any> {
      var cart = this.getSessionCart();
      if(cart){
        return this.http.put<Cart>(`${this.baseURL}/cart/calculate`, cart);
      }
      return new Observable<any>();
  }

  public setShoppingCart(cart: Cart) {
    localStorage.setItem(this.storageKey, JSON.stringify(cart));
  }

  add(productId: string, quantity: number): void {
      var cart = this.getSessionCart();
      if(!cart){
        cart = new Cart();
        cart.items.push(new CartItems(productId, quantity)); 
      } 
      else{
        let product = cart.items.find(x => x.productId == productId); 
        if(!product){
          cart.items.push(new CartItems(productId, quantity)); 
        }else{
          product.quantity = quantity;
        }
      }
      this.setShoppingCart(cart);
      this.calculateCart().subscribe(x => this.getCart());
  }

  remove(productId: string){
      var cart = this.getSessionCart();
      cart.items = cart.items.filter(x => x.productId != productId);
      this.setShoppingCart(cart);
  }
}

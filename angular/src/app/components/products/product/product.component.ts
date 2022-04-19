import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from 'src/app/models/product.model';
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
              private router: Router,
              private route: ActivatedRoute) { }

  ngOnInit() {
    this.productId = this.route.snapshot.params['id'];
    this.productsService.getProduct(this.productId).subscribe(product => this.product = product );
  }

}

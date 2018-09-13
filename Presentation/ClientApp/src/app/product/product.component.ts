import { Component, OnInit } from '@angular/core';
import {ApiService} from "../_services/api.service";

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
  products: any;

  constructor(private apiService: ApiService) { }

  ngOnInit() {
    this.loadProducts()
  }

  loadProducts() {
    this.apiService.getProducts().subscribe(products => {
      this.products = products;
    })
  }

}

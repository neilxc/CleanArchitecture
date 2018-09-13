import { Component, OnInit } from '@angular/core';
import {ApiService} from "../../_services/api.service";

@Component({
  selector: 'app-sale-list',
  templateUrl: './sale-list.component.html',
  styleUrls: ['./sale-list.component.css']
})
export class SaleListComponent implements OnInit {
  sales: any;

  constructor(private apiService: ApiService) { }

  ngOnInit() {
    this.loadSales()
  }

  loadSales() {
    this.apiService.getSales().subscribe(sales => {
      this.sales = sales;
    })
  }

}

import { Component, OnInit } from '@angular/core';
import {ApiService} from "../../_services/api.service";
import {ActivatedRoute} from "@angular/router";

@Component({
  selector: 'app-sale-detail',
  templateUrl: './sale-detail.component.html',
  styleUrls: ['./sale-detail.component.css']
})
export class SaleDetailComponent implements OnInit {
  sale: any;

  constructor(private apiService: ApiService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.loadSaleDetail()
  }

  loadSaleDetail() {
    this.apiService.getSaleDetails(this.route.snapshot.params['id']).subscribe(sale => {
      this.sale = sale;
    })
  }

}

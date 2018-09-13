import { Component, OnInit } from '@angular/core';
import {ApiService} from "../../_services/api.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-sale-form',
  templateUrl: './sale-form.component.html',
  styleUrls: ['./sale-form.component.css']
})
export class SaleFormComponent implements OnInit {
  saleFormDropDownValues: any;
  model: any = {};
  saleData: any = {};

  constructor(private apiService: ApiService, private route: Router) { }

  ngOnInit() {
    this.loadDropdownValues();
  }

  loadDropdownValues() {
    this.apiService.getDropdownValuesForForm().subscribe(values => {

      this.saleFormDropDownValues = values;
    })
  }

  createNewSale() {
    this.saleData.customerId = this.model.customer;
    this.saleData.employeeId = this.model.employee;
    this.saleData.productId = this.model.product;
    this.saleData.quantity = this.model.quantity;
    this.apiService.createSale(this.saleData).subscribe(() => {
      this.route.navigate(['/sales'])
    })
  }

}

import { Component, OnInit } from '@angular/core';
import {ApiService} from "../_services/api.service";

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.css']
})
export class CustomerComponent implements OnInit {
  customers: any;

  constructor(private apiService: ApiService) { }

  ngOnInit() {
    this.loadCustomers()
  }

  loadCustomers() {
    this.apiService.getCustomers().subscribe((customers) => {
      this.customers = customers;
    })
  }

}

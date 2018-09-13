import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";

@Injectable()
export class ApiService {

  constructor(private http: HttpClient) { }

  getCustomers() {
    return this.http.get('api/customers');
  }

  getEmployees() {
    return this.http.get('api/employees');
  }

  getProducts() {
    return this.http.get('api/products');
  }

  getSales() {
    return this.http.get('api/sales');
  }

  getSaleDetails(id) {
    return this.http.get('api/sales/' + id);
  }

  getDropdownValuesForForm() {
    return this.http.get('api/sales/saleFormValues');
  }

  createSale(sale) {
    return this.http.post('api/sales', {saleData: sale});
  }

}

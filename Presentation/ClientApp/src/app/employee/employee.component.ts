import { Component, OnInit } from '@angular/core';
import {ApiService} from "../_services/api.service";

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {
  employees: any;

  constructor(private apiService: ApiService) { }

  ngOnInit() {
    this.loadEmployees()
  }

  loadEmployees() {
    this.apiService.getEmployees().subscribe(employees => {
      this.employees = employees;
    })
  }

}

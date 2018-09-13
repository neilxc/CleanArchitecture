import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { CustomerComponent } from './customer/customer.component';
import {ApiService} from "./_services/api.service";
import { EmployeeComponent } from './employee/employee.component';
import { ProductComponent } from './product/product.component';
import { SaleListComponent } from './sales/sale-list/sale-list.component';
import { SaleDetailComponent } from './sales/sale-detail/sale-detail.component';
import { SaleFormComponent } from './sales/sale-form/sale-form.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    CustomerComponent,
    EmployeeComponent,
    ProductComponent,
    SaleListComponent,
    SaleDetailComponent,
    SaleFormComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'customers', component: CustomerComponent },
      { path: 'employees', component: EmployeeComponent },
      { path: 'products', component: ProductComponent },
      { path: 'sales', component: SaleListComponent },
      { path: 'sale/create', component: SaleFormComponent },
      { path: 'sale/:id', component: SaleDetailComponent },
    ])
  ],
  providers: [
    ApiService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

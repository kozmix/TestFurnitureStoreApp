import { Component, OnInit } from '@angular/core';
import { Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CustomerService } from '../../services/customer.service';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.css']
})

export class CustomersComponent implements OnInit {
  // public customers: TestCustomer[];
  public customers: any;

  // constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
  //  http.get<TestCustomer[]>(baseUrl + 'api/customers').subscribe(result => {
  //    this.customers = result;
  //  }, error => console.error(error));
  // }

  constructor(public customerService: CustomerService) { }

  ngOnInit() {
    this.customerService.getCustomers().subscribe(customers => {
      this.customerService.customersBs.next(customers);
      this.customers = this.customerService.customersBs;
    });
  }
}

interface TestCustomer {
  name: string;
  isPremium: boolean;
  dateOfFirstPurchase: string;
}

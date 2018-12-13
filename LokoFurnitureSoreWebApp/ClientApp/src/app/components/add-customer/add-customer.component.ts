import { Component, OnInit } from '@angular/core';
import { Inject } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { CustomerService } from '../../services/customer.service';

@Component({
  selector: 'app-add-customer',
  templateUrl: './add-customer.component.html',
  styleUrls: ['./add-customer.component.css']
})

export class AddCustomerComponent implements OnInit {
  successMsg: boolean = false;
  errorMsg: boolean = false;
  name: string;
  dateOfFirstPurchase = Date;
  isPremium: boolean;
  baseUrl: string;
  httpClient: HttpClient;

  constructor(
    private router: Router,
    private customerService: CustomerService
  ) { }

  ngOnInit() {
  }

  addCustomer({form, value, valid}) {
    form.reset();
    if (valid) {
      this.customerService.postAddCustomer(value).subscribe(
        res => {
          if (res === 'customerExists') {
            this.errorMsg = true;
            setTimeout(function() {
              this.errorMsg = false;
            }.bind(this), 2000);
          } else {
            console.log(res);
            this.successMsg = true;
            setTimeout(function() {
              this.successMsg = false;
            }.bind(this), 2000);

            this.customerService.getCustomers().subscribe(customers => {
              this.customerService.customersBs.next(customers);
            });
          }
        });
    } else {
      console.log('Form is not valid.');
    }
  }
}

interface Customer {
  name: string;
  isPremium: boolean;
  dateOfFirstPurchase: string;
}

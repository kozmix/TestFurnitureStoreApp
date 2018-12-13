import { Injectable } from '@angular/core';
import { Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { Observable } from "rxjs/Observable";

@Injectable()
export class CustomerService {
  public baseUrl: string;
  
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
   }

  public customersBs = new BehaviorSubject<Object>(null);

  getCustomers() {
    return this.http.get(this.baseUrl + 'api/customers');
  }

  getProduct(id) {
    return this.http.get(this.baseUrl + 'api/customers/' + id);
  }

  postAddCustomer(value) {
    return this.http.post(this.baseUrl + 'api/customers/create', value);
  }

  getEditCustomer(id) {
    console.log('Editing customer ' + id);
    return this.http.get(this.baseUrl + 'api/customers/edit/' + id);
  }

  postEditCustomer(value) {
    return this.http.put(this.baseUrl + 'api/customers/edit/' + value.id, value);
  }

  deleteCustomer(id) {
    return this.http.delete(this.baseUrl + 'api/customers/delete/' + id);
  }

}

interface Customer {
  name: string;
  isPremium: boolean;
  dateOfFirstPurchase: string;
}

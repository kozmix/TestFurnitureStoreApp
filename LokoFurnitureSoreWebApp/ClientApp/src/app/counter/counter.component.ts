import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CustomerService } from '../services/customer.service';
import { ProductService } from '../services/product.service';

@Component({
  selector: 'app-counter-component',
  templateUrl: './counter.component.html'
})
export class CounterComponent {
  public furnitureOrder: FurnitureOrder[];
  public currentRebate = 0;
  public totalPrice = 0;
  public name: string;
  public dateOfFirstPurchase = Date;
  public isPremium: boolean;
  public customers: Customer[];
  public products: FurnitureProduct[];
  public cacheProducts: FurnitureProduct[];
  public selectedCustomer: any;
  public selectedProduct: any;
  public selectedQuantity = 0;
  private baseUrl: any;
  private http: any;
  private errorMsg: any;
  private successMsg: any;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
    this.http = http;

    http.get<Customer[]>(baseUrl + 'api/customers').subscribe(result => {
      this.customers = result;
    }, error => console.error(error));

    http.get<FurnitureProduct[]>(baseUrl + 'api/products').subscribe(result => {
      this.products = result;
      this.cacheProducts = this.products;
    }, error => console.error(error));
  }

  public incrementCounter() {
    console.log(this.selectedProduct);
    console.log(this.selectedQuantity);
    this.totalPrice = this.selectedProduct.unitPrice * this.selectedQuantity;
  }

  public calculateDiscount({form, value, valid}) {
      if (valid) {
        this.http.post(this.baseUrl + 'api/orders/calculate', value).subscribe(
          res => {
            if (res === 'productExists') {
              this.errorMsg = true;
              setTimeout(function() {
                this.errorMsg = false;
              }.bind(this), 2000);
            } else {
              this.successMsg = true;
              setTimeout(function() {
                this.successMsg = false;
              }.bind(this), 2000);
            }
          });
      } else {
        console.log('Form is not valid.');
      }
    form.reset();
  }
}

interface Customer {
  name: string;
  isPremium: boolean;
  dateOfFirstPurchase: string;
}

interface FurnitureProduct {
  name: string;
  price: number;
  onSale: boolean;
}

interface FurnitureOrder {
  customerId: number;
  productId: number;
  unitPrice: number;
  quantity: number;
  totalPrice: number;
}

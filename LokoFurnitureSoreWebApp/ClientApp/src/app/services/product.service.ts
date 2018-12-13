import { Injectable } from '@angular/core';
import { Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';

@Injectable()
export class ProductService {
  public baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
   }

  public productsBs = new BehaviorSubject<Object>(null);

  getProducts() {
    return this.http.get(this.baseUrl + 'api/products');
  }

  getProduct(id) {
    return this.http.get(this.baseUrl + 'api/products/' + id);
  }

  postAddProduct(value) {
    return this.http.post(this.baseUrl + 'api/products/create', value);
  }

  getEditProduct(id) {
    console.log('Editing product ' + id);
    return this.http.get(this.baseUrl + 'api/products/edit/' + id);
  }

  postEditProduct(value) {
    return this.http.put(this.baseUrl + 'api/products/edit/' + value.id, value);
  }

  deleteProduct(id) {
    return this.http.delete(this.baseUrl + 'api/products/delete/' + id);
  }

}

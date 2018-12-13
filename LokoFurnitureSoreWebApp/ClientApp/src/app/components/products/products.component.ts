import { Component, OnInit } from '@angular/core';
import { Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ProductService } from '../../services/product.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {
  // public products: FurnitureProduct[];
  products: any;

  // constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
  //  http.get<FurnitureProduct[]>(baseUrl + 'api/products').subscribe(result => {
  //    this.products = result;
  //  }, error => console.error(error));
  // }

  constructor(public productService: ProductService) { }

  ngOnInit() {
    this.productService.getProducts().subscribe(products => {
      this.productService.productsBs.next(products);
      this.products = this.productService.productsBs;
    });
  }
}

interface FurnitureProduct {
  name: string;
  price: number;
  onSale: boolean;
}

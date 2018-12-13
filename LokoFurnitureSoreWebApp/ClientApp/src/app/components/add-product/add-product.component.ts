import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ProductService } from '../../services/product.service';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent implements OnInit {
  successMsg: boolean = false;
  errorMsg: boolean = false;
  name: string;
  price = Number;
  onSale: boolean;

  constructor(
    private router: Router,
    private productService: ProductService
  ) { }

  ngOnInit() {
  }

  addProduct({form, value, valid}) {
    form.reset();
    if (valid) {
      this.productService.postAddProduct(value).subscribe(
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

            this.productService.getProducts().subscribe(products => {
              this.productService.productsBs.next(products);
            });
          }
        });
    } else {
      console.log('Form is not valid.');
    }
  }
}

interface FurnitureProduct {
  name: string;
  price: number;
  onSale: boolean;
}

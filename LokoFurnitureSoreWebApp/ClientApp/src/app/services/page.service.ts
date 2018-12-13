import { Injectable } from '@angular/core';
import { Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';

@Injectable()
export class PageService {
  public baseUrl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
   }

  public pagesBs = new BehaviorSubject<Object>(null);

  getPages() {
    return this.http.get(this.baseUrl + 'api/SampleData/WeatherForecasts');
  }

}

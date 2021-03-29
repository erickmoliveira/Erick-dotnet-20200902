import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public products: Product[];
  public model: Model;
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {

    

    http.get<Model>(baseUrl + 'Products/GetProducts/' + '100/0', { headers: new HttpHeaders().set("apikey", "MYTESTAPIKEY")}).subscribe(result => {
      this.model = result;
      this.products = this.model.Items;
      console.log(this.products.length);
    }, error => console.error(error));
  }
}
interface Model {
  Page_Size: string;
  Page_Number: string;
  Items: Product[];
}
interface Product {
  _id: string;
  Status: string;
  Image_Url: string;
  Creator: string;
}

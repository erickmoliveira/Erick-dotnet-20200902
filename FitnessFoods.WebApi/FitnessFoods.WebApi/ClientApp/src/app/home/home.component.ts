import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, Inject } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public model: Cron;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {



    http.get<Cron>(baseUrl + 'Cron', { headers: new HttpHeaders().set("apikey", "MYTESTAPIKEY") }).subscribe(result => {
      this.model = result;
      console.log(this.model)
    }, error => console.error(error));
  }
}


interface Cron {
  _id: string;
  ImportDateTime: string;
  NumberofObjects: string;
  ImportTime: string;
}

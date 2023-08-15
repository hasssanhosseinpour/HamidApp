import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  title = 'HamidApp';
  //color: any;
  color: any = { hexa: '#FFFFFF' };

  constructor(private http:HttpClient){}

  ngOnInit(): void {
    this.changeColor();
  }
  changeColor(){
    this.http.get('https://localhost:7071/api/colors').subscribe({
      next: response=> this.color = response,
      error: error => console.log(error),
      complete: () => console.log("Request is completed!")
    })
  }

}

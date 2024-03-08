import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-main',
  templateUrl: './main.layout.html',
  styleUrls: ['./main.layout.css']
})
export class MainLayout {
  constructor(private http: HttpClient) {}

  getData() {
this.http
	.get('https://localhost:7158/api/persons/')
	.subscribe(data => {
		console.log(data);
	});
  }
}
import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FetchDataService } from './service/fetch-data.service';
import { Person } from '../models/person';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent implements OnInit {

  public persons: Person[];

  constructor(@Inject('BASE_URL') baseUrl: string, private fetchDataService: FetchDataService) {

  }

  getAllPersonData(): void {
    this.fetchDataService.getPersonDataService().subscribe(data => this.persons = data);

  }

  ngOnInit() {
    console.log("test");
    this.getAllPersonData();
  }

}

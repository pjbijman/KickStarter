
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Person } from '../../models/person';

@Injectable()
export class FetchDataService {

  constructor(private http: HttpClient) { }

  getPersonDataService() {
    console.log("getPersonData");
    return this.http.get<Person[]>('http://localhost:20939/api/Person/GetPersonsAsync');
  }

}

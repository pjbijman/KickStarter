import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Person } from "./person";

@Injectable({
  providedIn: 'root'
})
export class GetDataService {
 
  //public url: 'http://localhost:20939/api/Person/GetPersonsAsync';
  
  
  constructor(private http: HttpClient ) { }

  getPersonData(){ 
    console.log("getPersonData");
    return this.http.get<Person[]>('http://localhost:20939/api/Person/GetPersonsAsync'); 
  }

    
}



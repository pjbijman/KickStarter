import { Component, OnInit, Inject } from '@angular/core';
import { GetDataService } from '../get-data.service';
import { Person } from "../person";
import { HttpClient} from '@angular/common/http';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.scss']
})
export class IndexComponent implements OnInit {

  public getAllPersonData: Person[];
  //public forecasts: WeatherForecast[];


  constructor(private getDataService: GetDataService) { }
  
  getAllPersonsData(): void{
    console.log("test 2");
    this.getDataService.getPersonData()
    .subscribe(data => this.getAllPersonData = data)
    

    // this.http.get<WeatherForecast[]>(this.baseUrl + 'api/SampleData/WeatherForecasts').subscribe(result => {
    //   this.forecasts = result;
    // }, error => console.error(error));
  }

  ngOnInit() {
    console.log("test");
    this.getAllPersonsData();
  }

}

// interface WeatherForecast {
//   dateFormatted: string;
//   temperatureC: number;
//   temperatureF: number;
//   summary: string;
// }

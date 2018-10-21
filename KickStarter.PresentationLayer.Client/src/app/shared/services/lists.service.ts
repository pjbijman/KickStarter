import { Injectable } from "@angular/core";
import { Http } from "@angular/http";
import { Observable } from "rxjs/Observable";
import { ErrorHandlerService } from "./errorhandler.service";
import { MapService } from "./map.service";
import { ListOption } from "../models/listoption.model";

@Injectable()
export class ListsService {
	private listsUrl = "api/lists";

	constructor(private http: Http,
		private errorHandlerService: ErrorHandlerService,
		private mapService: MapService) {
	}

	getItemTypes(): Observable<ListOption[]> {
		return this.http.get(`${this.listsUrl}/GetItemTypes`)
			.map(this.mapService.extractData)
			.catch(this.errorHandlerService.handleError);
	}

	getPriceUnits(): Observable<ListOption[]> {
		return this.http.get(`${this.listsUrl}/GetPriceUnits`)
			.map(this.mapService.extractData)
			.catch(this.errorHandlerService.handleError);
	}

	getTimeFactors(): Observable<ListOption[]> {
		return this.http.get(`${this.listsUrl}/GetTimeFactors`)
			.map(this.mapService.extractData)
			.catch(this.errorHandlerService.handleError);
	}
}

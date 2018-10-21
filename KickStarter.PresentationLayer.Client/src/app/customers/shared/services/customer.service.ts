import { Injectable } from "@angular/core";
import { Http } from "@angular/http";
import { Observable } from "rxjs/Observable";
import { Customer } from "../../../shared/models/customer.model";
import { CustomerListItem } from "../../shared/models/customerlistitem.model";
import { ErrorHandlerService } from "../../../shared/services/errorhandler.service";
import { MapService } from "../../../shared/services/map.service";
import { Event } from "../../../events/shared/models/event.model";

@Injectable()
export class CustomerService {
	private customerApiUrl = "api/Customer";
	private eventApiUrl = "api/Event";

	constructor(private http: Http, private errorHandlerService: ErrorHandlerService, private mapService: MapService) {}

	getEventsByCustomerId(id: number): Observable<Event[]> {
		return this.http.get(`${this.eventApiUrl}/GetCustomerEventList/${id}`)
			.map(this.mapService.extractData)
			.catch(this.errorHandlerService.handleError);
	}

	/**
	 * Get customers from database
	 */
	getCustomers(): Observable<CustomerListItem[]> {
		return this.http.get(`${this.customerApiUrl}/GetCustomerList`)
			.map(this.mapService.extractData)
			.catch(this.errorHandlerService.handleError);
	}

	/**
	 * Get customer
	 * @param id
	 */
	getCustomer(id: number): Observable<Customer> {
		return this.http.get(`${this.customerApiUrl}/GetCustomer/${id}`)
			.map(this.mapService.extractData)
			.catch(this.errorHandlerService.handleError);
	}

	/**
	 * Get customer detail dropdown data
	 */
	getCustomerDetailDropDownData(): Observable<Customer> {
		return this.http.get(`${this.customerApiUrl}/GetCustomer`)
			.map(this.mapService.extractData)
			.catch(this.errorHandlerService.handleError);
	}

	/**
	  * Save customer     
	  */
	saveCustomer(customer: Customer): Observable<void> {
		return this.http.post(`${this.customerApiUrl}/SaveCustomer`, customer)
			.map(this.mapService.extractVoid)
			.catch(this.errorHandlerService.handleError);
	}
}

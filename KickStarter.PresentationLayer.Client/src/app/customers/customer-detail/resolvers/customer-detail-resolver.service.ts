import { Injectable } from "@angular/core";
import { Router, Resolve, RouterStateSnapshot, ActivatedRouteSnapshot } from "@angular/router";
import { Observable } from "rxjs/Observable";

import { CustomerService } from "../../shared/services/customer.service";
import { LoadingService } from "../../../shared/loading/loading.service";
import { MessageService } from "../../../shared/message/message.service";
import { Customer } from "../../../shared/models/customer.model";

@Injectable()
export class CustomerDetailResolver implements Resolve<Customer> {
	constructor(
		private router: Router,
		private messageService: MessageService,
		private loadingService: LoadingService,
		private customerService: CustomerService,
	) {
	}

	resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<Customer> {
		const id = parseInt(route.paramMap.get("id"));
		const mode = route.paramMap.get("mode");

		this.loadingService.toggleLoading(true);
		if (id > 0 && mode == null) {
			//ID has been provided, get pricelistitem
			return this.customerService.getCustomer(id).map((customer: Customer) => {
				this.loadingService.toggleLoading(false);
				if (customer) {
					return customer;
				} else { // id not found
					//this.router.navigate(["/klanten"]);
					this.messageService.addMessage("Klant kon niet worden gevonden.", "danger");
					return null;
				}
			});
		} else if (route.paramMap.get("id") === "nieuw") {
			this.loadingService.toggleLoading(false);
			return null;
		} else {
			//Not a valid route, redirect to overview            
			this.router.navigate(["/klanten"]);
			this.loadingService.toggleLoading(false);
			return null;
		}
	}
}

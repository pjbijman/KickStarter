import { Component, OnInit, OnDestroy } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { Subscription } from "rxjs/Subscription";

import { CustomerListItem } from "../shared/models/customerlistitem.model";

import { CustomerService } from "../shared/services/customer.service";
import { LoadingService } from "../../shared/loading/loading.service";
import { MessageService } from "../../shared/message/message.service";

@Component({
	templateUrl: "./customer-list.component.html",
	styleUrls: ["./customer-list.component.scss"]
})
export class CustomerListComponent implements OnInit, OnDestroy {
	isLoading = true;
	private loadingSubscription: Subscription;
	private customers: CustomerListItem[];
	sortParameter = "id";
	sortReverse = true;

	constructor(
		private router: Router,
		private route: ActivatedRoute,
		private loadingService: LoadingService,
		private messageService: MessageService,
		private customerService: CustomerService
	) {
		this.handleLoading();
	}

	ngOnInit(): void {

		this.getCustomers();
	}

	/**
	 * Get customerlist from database
	 */
	private getCustomers(): void {
		this.loadingService.toggleLoading(true);
		this.customerService.getCustomers()
			.subscribe(
				customers => {
					if (customers && customers.length > 0) {
						this.customers = customers;
					} else {
						this.messageService.addMessage("Er zijn geen klanten gevonden.", "info");
					}
				},
				error => {
					this.messageService.addMessage(`Klanten konden niet worden opgehaald. ${error}`, "danger");
					this.loadingService.toggleLoading(false);
				},
				() => {
					this.loadingService.toggleLoading(false);
				}
			);
	}

	/**
	 * Redirect to edit item
	 */
	private addItem(): void {
		this.router.navigate(["nieuw"], { relativeTo: this.route });
	}

	/**
	 * Redirect to edit item
	 * @param item
	 */
	private editItem(customer: CustomerListItem): void {
		this.router.navigate([`bewerk/${customer.id}`], { relativeTo: this.route });
	}

	private readItem(customer: CustomerListItem): void {
		this.router.navigate([customer.id], { relativeTo: this.route });
	}

	changeSort(sortParameter: string, defaultReverse: boolean = false): void {
		if (this.sortParameter != sortParameter) {
			this.sortParameter = sortParameter;
			this.sortReverse = defaultReverse;
		} else {
			this.sortReverse = !this.sortReverse;
		}
	}

	/**
	 * Set isloading variable when loading data
	 */
	private handleLoading(): void {
		this.loadingSubscription = this.loadingService.getLoadingStatus()
			.subscribe(
				loading => {
					this.isLoading = loading.isLoading;
				});
	}

	ngOnDestroy() {
		// unsubscribe to ensure no memory leaks
		this.loadingSubscription.unsubscribe();
	}
}

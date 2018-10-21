import { Component, OnDestroy } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { FormBuilder, FormGroup, Validators, FormArray } from "@angular/forms";
import { Subscription } from "rxjs/Subscription";

import { Customer } from "../../shared/models/customer.model";
import { ViewMode } from "../../shared/enums/view-modes.enum";

import { CustomerService } from "../shared/services/customer.service";
import { LoadingService } from "../../shared/loading/loading.service";
import { MessageService } from "../../shared/message/message.service";
import { Event } from "../../events/shared/models/event.model";


const emailRegex = new RegExp("^[^\\s@]+@[^\\s@]+\\.[^\\s@]+$");
const phoneRegex = new RegExp("^[0-9]{10}$");


@Component({
	templateUrl: "./customer-detail.component.html",
	styleUrls: ["./customer-detail.component.scss"]
})
export class CustomerDetailComponent implements OnDestroy {
	isLoading = false;
	viewModeEnum = ViewMode;
	viewMode = ViewMode.View;
	private editMode = false;
	private readMode = false;
	private newMode = false;

	private loadingSubscription: Subscription;
	private customer: Customer;
	private customerForm: FormGroup;
	private customerContacts: any[] = [];
	private customerEvents: any[] = [];

	errorMessage: String;

	constructor(
		private readonly customerService: CustomerService,
		private readonly route: ActivatedRoute,
		private readonly router: Router,
		private readonly formBuilder: FormBuilder,
		private readonly loadingService: LoadingService,
		private readonly messageService: MessageService,
	) {
		this.handleLoading();
	}

	ngOnInit(): void {
		this.route.data.subscribe((data: { customer: Customer }) => {
			if (data.customer == null) {
				this.customer = new Customer();
				this.viewMode = ViewMode.New;
			} else {
				this.customer = data.customer;
				this.viewMode = ViewMode.View;
			}
			this.getEventsByCustomerId();
			this.createForm();
		});
	}


	private getEventsByCustomerId(): void {
		this.customerService.getEventsByCustomerId(this.customer.id)
			.subscribe(
				customerEvents => this.customerEvents = customerEvents,
				error => this.errorMessage = error
			);
	}


	/**
	  * Set default values
	  */
	private createForm(): void {
		this.customerForm = this.formBuilder.group({
			id: [this.customer.id],
			name: [
				{ value: this.customer ? this.customer.name : "", disabled: this.viewMode === ViewMode.View },
				Validators.compose([Validators.required])
			],
			email: [
				{
					value: this.customer && this.customer.email ? this.customer.email : "",
					disabled: this.viewMode === ViewMode.View
				},
				Validators.compose([Validators.required, Validators.pattern(emailRegex)])
			],
			phoneNumber: [
				{ value: this.customer ? this.customer.phoneNumber : "", disabled: this.viewMode === ViewMode.View },
				Validators.compose([Validators.pattern(phoneRegex)])
			],
			coCNumber: [
				{ value: this.customer ? this.customer.coCNumber : "", disabled: this.viewMode === ViewMode.View },
				Validators.compose([Validators.required])
			],
			active: [
				{ value: this.customer ? this.customer.active : false, disabled: this.viewMode === ViewMode.View }
			],

			houseNumber: [
				{ value: this.customer ? this.customer.houseNumber : "", disabled: this.viewMode === ViewMode.View },
				Validators.compose([Validators.required])
			],
			houseNumberAttachment: [
				{
					value: this.customer ? this.customer.houseNumberAttachment : "",
					disabled: this.viewMode === ViewMode.View
				}, Validators.compose([])
			],
			street: [
				{ value: this.customer ? this.customer.street : "", disabled: this.viewMode === ViewMode.View },
				Validators.compose([Validators.required])
			],
			zipCode: [
				{ value: this.customer ? this.customer.zipCode : "", disabled: this.viewMode === ViewMode.View },
				Validators.compose([Validators.required])
			],
			city: [
				{ value: this.customer ? this.customer.city : "", disabled: this.viewMode === ViewMode.View },
				Validators.compose([Validators.required])
			],

			invoiceHouseNumber: [
				{
					value: this.customer ? this.customer.invoiceHouseNumber : "",
					disabled: this.viewMode === ViewMode.View
				}, Validators.compose([Validators.required])
			],
			invoiceHouseNumberAttachment: [
				{
					value: this.customer ? this.customer.invoiceHouseNumberAttachment : "",
					disabled: this.viewMode === ViewMode.View
				}, Validators.compose([])
			],
			invoiceStreet: [
				{ value: this.customer ? this.customer.invoiceStreet : "", disabled: this.viewMode === ViewMode.View },
				Validators.compose([Validators.required])
			],
			invoiceZipCode: [
				{ value: this.customer ? this.customer.invoiceZipCode : "", disabled: this.viewMode === ViewMode.View },
				Validators.compose([Validators.required])
			],
			invoiceCity: [
				{ value: this.customer ? this.customer.invoiceCity : "", disabled: this.viewMode === ViewMode.View },
				Validators.compose([Validators.required])
			],
			customerContacts: this.formBuilder.array(this.initContacts())
		});
		this.customerForm.valueChanges.subscribe(data => this.onValueChanged(data));
		this.onValueChanged();
	}

	/**
   * Handle input value changes inside customerform
   * @param data
   */
	onValueChanged(data?: any) {
		if (!this.customerForm) {
			return;
		}
		const form = this.customerForm;
		const formErrors = this.formErrors;
		for (const field in formErrors) {
			if (formErrors.hasOwnProperty(field)) {
				// clear previous error message (if any)
				formErrors[field] = "";
				const control = form.get(field);
				if (control && control.dirty && !control.valid) {
					const messages = this.validationMessages[field];
					for (const key in control.errors) {
						if (control.errors.hasOwnProperty(key)) {
							formErrors[field] += messages[key] + " ";
						}
					}
				}
			}
		}
	}

	private formErrors = {
		'name': "",
		'email': "",
		'phoneNumber': "",
		'coCNumber': "",
		'street': "",
		'houseNumber': "",
		'zipCode': "",
		'city': "",
		'invoiceStreet': "",
		'invoiceHouseNumber': "",
		'invoiceZipCode': "",
		'invoiceCity': ""
	};

	private validationMessages = {
		'name': {
			'required': "Naam is verplicht."
		},
		'email': {
			'required': "E-mailadres is verplicht.",
			'pattern': "Voer een valide e-mailadres in."
		},
		'phoneNumber': {
			'required': "Telefoonnummer is verplicht.",
			'pattern': "Voer een valide telefoonnummer in."
		},
		'coCNumber': {
			'required': "KVK nummer is verplicht.",
			'pattern': "Voer een valide KVK nummer in."
		},
		'street': {
			'required': "Straat is verplicht.",
			'pattern': "Voer een valide telefoonnummer in."
		},
		'zipCode': {
			'required': "Postcode is verplicht."
		},
		'houseNumber': {
			'required': "Huisnummer is verplicht.",
			'pattern': "Voer een valide telefoonnummer in."
		},
		'city': {
			'required': "Plaats is verplicht.",
		},
		'invoiceStreet': {
			'required': "Straat is verplicht.",
			'pattern': "Voer een valide telefoonnummer in."
		},
		'invoiceHouseNumber': {
			'required': "Huisnummer is verplicht.",
			'pattern': "Voer een valide telefoonnummer in."
		},
		'invoiceHouseNumberAttachment': {
			'required': "Huisnummer is verplicht.",
			'pattern': "Voer een valide telefoonnummer in."
		},
		'invoiceZipCode': {
			'required': "Postcode is verplicht."
		},
		'invoiceCity': {
			'required': "Plaats is verplicht."
		}
	};

	/**
	  * Save customer
	  * @param value
	  */
	private onSubmit(customerForm: FormGroup) {
		this.loadingService.toggleLoading(true);
		this.messageService.removeAllMessages();

		this.customerService.saveCustomer(customerForm.value).subscribe(() => {
				this.messageService.addMessage("Klant is succesvol opgeslagen", "success");
				this.gotoViewMode();
			},
			error => {
				this.messageService.addMessage(`Klant kon niet worden opgeslagen: ${error}`, "danger");
				this.loadingService.toggleLoading(false);
			},
			() => {
				this.loadingService.toggleLoading(false);
			}
		);
	}

	/**
	* Redirect to overview
	*/
	goToCustomers(): void {
		this.router.navigate(["/klanten"]);
	}

	private readItem(event: Event): void {
		this.router.navigate([`/evenementen/${this.customer.id}/${event.id}`], { relativeTo: this.route });
	}

	/**
 * Redirect to edit item
 */
	private addNewEvent(customer: Customer): void {
		//this.router.navigate([`/evenementen/${customer.id}/nieuw`], { relativeTo: this.route });
	}

	refresh(): void {
		window.location.reload();
	}

	gotoViewMode(): void {
		this.viewMode = ViewMode.View;
		this.toggleForm(true);
	}

	/**
	 * Change viewmode to edit
	 */
	goToEditMode(): void {
		this.viewMode = ViewMode.Edit;
		this.toggleForm(false);
	}

	/**
	 * Intialize contacts form group
	 */
	initContacts(): FormGroup[] {
		const contacts = [];
		if (this.customer.customerContacts && this.customer.customerContacts.length > 0) {
			for (let contact of this.customer.customerContacts) {
				contacts.push(this.formBuilder.group({
					id: [{ value: contact.id, disabled: this.viewMode === ViewMode.View }],
					name: [
						{ value: contact.name, disabled: this.viewMode === ViewMode.View },
						Validators.compose([Validators.required])
					],
					phoneNumber: [
						{ value: contact.phoneNumber, disabled: this.viewMode === ViewMode.View },
						Validators.compose([Validators.pattern(phoneRegex)])
					],
					email: [
						{ value: contact.email, disabled: this.viewMode === ViewMode.View },
						Validators.compose([Validators.pattern(emailRegex)])
					]
				}));
			}
		}

		return contacts;
	}

	/**
	 * Create an new contact
	 */
	createContact(): FormGroup {
		return this.formBuilder.group({
			id: [{ value: null, disabled: this.viewMode === ViewMode.View }],
			name: [{ value: "", disabled: this.viewMode === ViewMode.View }, Validators.compose([Validators.required])],
			phoneNumber: [
				{ value: "", disabled: this.viewMode === ViewMode.View },
				Validators.compose([Validators.pattern(phoneRegex)])
			],
			email: [
				{ value: "", disabled: this.viewMode === ViewMode.View },
				Validators.compose([Validators.pattern(emailRegex)])
			]
		});
	}

	/**
	 * Add contact to list
	 */
	addContact(): void {
		const control = this.customerForm.controls["customerContacts"] as FormArray;
		control.push(this.createContact());
	}

	/**
	 * Remove contact from list
	 * @param i
	 */
	removeContact(i: number): void {
		const control = this.customerForm.controls["customerContacts"] as FormArray;
		control.removeAt(i);
	}

	/**
	 * Toggle all inputs
	 */
	private toggleForm(disable: boolean): void {
		const controls = this.customerForm.controls;
		for (const field in controls) {
			if (controls.hasOwnProperty(field)) {
				const control = this.customerForm.get(field);
				disable ? control.disable() : control.enable();
			}
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

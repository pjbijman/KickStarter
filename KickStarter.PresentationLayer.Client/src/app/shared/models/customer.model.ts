import { CustomerContact } from "./customercontact.model";
import { Event } from "../../events/shared/models/event.model";

export class Customer {
	id: number;
	name: string;
	email: string;
	phoneNumber: string;
	coCNumber: string;
	active: boolean;

	street: string;
	houseNumber?: number;
	houseNumberAttachment: string;
	zipCode: string;
	city: string;

	invoiceStreet: string;
	invoiceHouseNumber?: number;
	invoiceHouseNumberAttachment: string;
	invoiceZipCode: string;
	invoiceCity: string;

	customerContacts: CustomerContact[];
	customerEvents: Event[];
}

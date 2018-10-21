import { Component, Inject, LOCALE_ID } from "@angular/core";
import { Router } from "@angular/router";
import "./rxjs-operators";

@Component({
	selector: "app-root",
	templateUrl: "./app.component.html",
	styleUrls: ["./app.component.scss"]
})
export class AppComponent {
	date = new Date();

	constructor(private router: Router,
		@Inject(LOCALE_ID) locale: string) {
	}
}

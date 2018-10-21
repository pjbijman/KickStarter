import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";

import { BreadcrumbComponent } from "./breadcrumb.component";
import { AppRoutingModule } from "../../app-routing.module";

@NgModule({
	imports: [
		CommonModule,
		AppRoutingModule
	],
	declarations: [
		BreadcrumbComponent
	],
	exports: [BreadcrumbComponent],
	providers: [
	]
})
export class BreadcrumbModule {
}

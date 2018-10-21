import { NgModule } from "@angular/core";

import { RouterModule, Routes, Router, NavigationEnd } from "@angular/router";
import { CustomerComponent } from "./customers/customer.component";
import { CustomerListComponent } from "./customers/customer-list/customer-list.component";
import { CustomerDetailComponent } from "./customers/customer-detail/customer-detail.component";
import { PageNotFoundComponent } from "./not-found.component";
import { HomeComponent } from "./home/home.component";
import { CustomerDetailResolver } from "./customers/customer-detail/resolvers/customer-detail-resolver.service";
import { MessageService } from "./shared/message/message.service";

let server = false;
if (typeof window === "undefined") {
	server = true;
}

export const appRoutes: Routes = [
	{
		path: "",
		redirectTo: "/home",
		pathMatch: "full"
	},
	{
		path: "klanten",
		component: CustomerComponent,
		data: { breadcrumb: "Klanten" },
		children: [
			{
				path: "",
				component: CustomerListComponent,
			},
			{
				path: ":id",
				component: CustomerDetailComponent,
				resolve: {
					customer: CustomerDetailResolver
				},
				data: {
					breadcrumb: "Details"
				}
			},
			{
				path: ":mode/:id",
				component: CustomerDetailComponent,
				resolve: {
					customer: CustomerDetailResolver
				},
				pathMatch: "full",
				data: {
					breadcrumb: "Details"
				}
			},
			{
				path: "nieuw",
				component: CustomerDetailComponent,
				resolve: {
					customer: CustomerDetailResolver
				},
				data: {
					breadcrumb: "Details"
				}
			}
		]
	},
	{
		path: "home",
		component: HomeComponent
	},
	{
		path: "**",
		component: PageNotFoundComponent
	}
];

@NgModule({
	imports: [RouterModule.forRoot(appRoutes)],
	exports: [RouterModule],
	providers: [
		CustomerDetailResolver
	]
})
export class AppRoutingModule {
	constructor(private router: Router, private messageService: MessageService) {
		router.events.subscribe((event) => {
			if (event) {
				if (event instanceof NavigationEnd) {
					this.messageService.removeAllMessages();
				}
			}
		});
	}
}

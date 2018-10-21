import { Component, OnInit } from "@angular/core";
import { Router, ActivatedRoute, NavigationEnd, PRIMARY_OUTLET } from "@angular/router";
import "rxjs/add/operator/filter";

import { Breadcrumb } from "./breadcrumb.model";

@Component({
	selector: "breadcrumb",
	templateUrl: "breadcrumb.component.html",
	styles: [
		`
		ol.breadcrumb > li:last-child a.active{color:#969696 !important;text-decoration:none;}
	`
	]
})
export class BreadcrumbComponent implements OnInit {
	breadcrumbs: Breadcrumb[];

	constructor(
		private activatedRoute: ActivatedRoute,
		private router: Router) {

	}

	ngOnInit() {
		//subscribe to the NavigationEnd event
		this.router.events.filter(event => event instanceof NavigationEnd).subscribe(event => {

			//set breadcrumbs
			const root = this.activatedRoute.root;
			this.breadcrumbs = this.getBreadcrumbs(root);
		});
	}

	private getBreadcrumbs(route: ActivatedRoute, url: string = "", breadcrumbs: Breadcrumb[] = []): Breadcrumb[] {
		const routeDataBreadcrumb = "breadcrumb";

		//get the child routes
		const children = route.children;

		//return if there are no more children
		if (children.length === 0) {
			return breadcrumbs;
		}

		//iterate over each children
		for (let child of children) {
			//verify primary route
			if (child.outlet !== PRIMARY_OUTLET) {
				continue;
			}

			//verify the custom data property "breadcrumb" is specified on the route
			if (!child.snapshot.data.hasOwnProperty(routeDataBreadcrumb)) {
				return this.getBreadcrumbs(child, url, breadcrumbs);
			}

			//get the route's URL segment
			const routeURL = child.snapshot.url.map(segment => segment.path).join("/");

			//append route URL to URL
			url += `/${routeURL}`;

			//add breadcrumb
			const breadcrumb: Breadcrumb = {
				label: child.snapshot.data[routeDataBreadcrumb],
				params: child.snapshot.params,
				url: url
			};

			if (!breadcrumbs.some(x => x.label === breadcrumb.label)) {
				breadcrumbs.push(breadcrumb);
			}

			//recursive
			return this.getBreadcrumbs(child, url, breadcrumbs);
		}

		//we should never get here, but just in case
		return breadcrumbs;
	}
}

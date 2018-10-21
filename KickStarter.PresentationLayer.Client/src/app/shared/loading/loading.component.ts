import { Component, OnDestroy } from "@angular/core";
import { Subscription } from "rxjs/Subscription";

import { LoadingService } from "./loading.service";

@Component({
	selector: "loading",
	templateUrl: "loading.component.html",
	styleUrls: ["loading.component.scss"]
})
export class LoadingComponent implements OnDestroy {
	isLoading = false;
	private loadingSubscription: Subscription;

	constructor(private loadingService: LoadingService) {
		this.handleLoading();
	}

	/**
	 * Set isloading variable when loading data
	 */
	private handleLoading(): void {
		this.loadingSubscription = this.loadingService.getLoadingStatus().subscribe(
			loading => {
				this.isLoading = loading.isLoading;
			});
	}

	ngOnDestroy() {
		// unsubscribe to ensure no memory leaks
		this.loadingSubscription.unsubscribe();
	}
}

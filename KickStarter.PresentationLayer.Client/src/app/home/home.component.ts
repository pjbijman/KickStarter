import { Component, OnInit, OnDestroy, Input } from "@angular/core";
import { Router, ActivatedRoute } from "@angular/router";
import { Subscription } from "rxjs/Subscription";
import { LoadingService } from "../shared/loading/loading.service";

@Component({
	templateUrl: "./home.component.html",
	styleUrls: ["./home.component.scss"]
})
export class HomeComponent implements OnInit, OnDestroy {
	customerId: number;
	isLoading = true;
	private loadingSubscription: Subscription;
	private events: Event[];

	sortParameter = "id";
	sortReverse = true;
	numberEventDays: number;

	constructor(
		private router: Router,
		private loadingService: LoadingService,
		private route: ActivatedRoute
	
	) {
		this.handleLoading();
	}

	ngOnInit(): void {


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

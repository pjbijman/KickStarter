import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Observable";
import { Subject } from "rxjs/Subject";

@Injectable()
export class LoadingService {
	private loadingSource = new Subject<any>();

	/** Toggle loading GIF */
	toggleLoading(loading: boolean): void {
		this.loadingSource.next({ isLoading: loading });
	}

	getLoadingStatus(): Observable<any> {
		return this.loadingSource.asObservable();
	}
}

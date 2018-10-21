import { Injectable } from "@angular/core";
import { Response } from "@angular/http";
import { Observable } from "rxjs/Observable";

@Injectable()
export class ErrorHandlerService {
	/**
	  * Handle webapi errors
	  * @param error
	  */
	handleError(error: Response | any) {
		// In a real world app, you might use a remote logging infrastructure
		let errMsg: string;
		if (error instanceof Response) {
			try {
				const body = error.json() || "";
				const err = body.error || JSON.stringify(body);
				errMsg = `${error.status} - ${error.statusText || ""} ${err}`;
			} catch (e) {
				// Response could not be parsed to json
				errMsg = "Ongeldig resultaat ontvangen.";
			}

		} else {
			errMsg = error.message ? error.message : error.toString();
		}
		console.error(errMsg);
		return Observable.throw(errMsg);
	}
}

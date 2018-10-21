import { Injectable } from "@angular/core";
import { Response } from "@angular/http";

@Injectable()
export class MapService {
	/**
	  * Get data from response
	  * @param res
	  */
	extractData(res: Response): Object {
		const body = res.json();
		return body || {};
	}

	/**
	 * Return boolean for webapi methods that return void such as save
	 * @param res
	 */
	extractVoid(res: Response): boolean {
		return res.ok;
	}

	/**
	 * Get blob from response
	 * @param res
	 */
	extractBlob(res: Response): Blob {
		if (res.status === 200) {
			return new Blob([res.blob()],
				{
					type: res.headers.get("Content-Type")
				});
		}

		return null;
	}
}

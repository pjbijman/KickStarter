import { Pipe, PipeTransform } from "@angular/core";

@Pipe({
	name: "sort",
	pure: false
})
export class SortPipe implements PipeTransform {

	// before using this, keep in mind that this practice is recommended *against* by Angular itself
	// due to this method being very slow
	// see: https://angular.io/guide/pipes#appendix-no-filterpipe-or-orderbypipe

	transform(items: any[], parameter: string, reverse: boolean = false): any {
		if (!items) {
			return items;
		}
		const lowerVal = reverse ? 1 : -1;
		const higherVal = reverse ? -1 : 1;
		return items.sort(
			function(a: any, b: any): number {
				if (a[parameter] > b[parameter])
					return higherVal;
				else if (a[parameter] < b[parameter])
					return lowerVal;
				return 0;
			}
		);
	}
}

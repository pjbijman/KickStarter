import { Pipe, PipeTransform } from "@angular/core";

@Pipe({
	name: "activeFilter",
	pure: false
})
export class ActiveFilterPipe implements PipeTransform {
	transform(items: any[], onlyActive: boolean): any {
		if (!items || !onlyActive) {
			return items;
		}
		const filteredList: any[] = [];
		for (let i = 0; i < items.length; i++)
			if (items[i].active)
				filteredList.push(items[i]);
		return filteredList;
	}
}

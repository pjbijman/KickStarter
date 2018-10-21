import { NgModule } from "@angular/core";
import { SortPipe } from "./sort.pipe";
import { ActiveFilterPipe } from "./active-filter.pipe";

@NgModule({
	declarations: [
		SortPipe,
		ActiveFilterPipe,
	],
	exports: [
		SortPipe,
		ActiveFilterPipe,
	]
})
export class PipeModule {
}

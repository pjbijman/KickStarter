import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";

import { AlertModule, AlertConfig } from "ngx-bootstrap/alert";

import { MessageComponent } from "./message.component";
import { MessageService } from "./message.service";

@NgModule({
	imports: [
		AlertModule,
		CommonModule
	],
	declarations: [
		MessageComponent
	],
	exports: [MessageComponent],
	providers: [
		MessageService,
		AlertConfig
	]
})
export class MessageModule {
}

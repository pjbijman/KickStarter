import { NgModule, LOCALE_ID } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { HttpModule } from "@angular/http";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { AppRoutingModule } from "./app-routing.module";
import { BreadcrumbModule } from "./shared/breadcrumb/breadcrumb.module";
import { AppComponent } from "./app.component";
import { PageNotFoundComponent } from "./not-found.component";
import { ErrorHandlerService } from "./shared/services/errorhandler.service";
import { MapService } from "./shared/services/map.service";
import { ListsService } from "./shared/services/lists.service";
import { PipeModule } from "./shared/pipes/pipe.module";
import { registerLocaleData } from "@angular/common";
import localeNl from "@angular/common/locales/nl";
import { CapitalizeFirstPipe } from "./shared/pipes/capitalizeFirst.pipe";
import { MessageModule } from "./shared/message/message.module";
import { NavigationEnd, Router } from "@angular/router";
import { MessageService } from "./shared/message/message.service";



registerLocaleData(localeNl);

@NgModule({
	declarations: [
		AppComponent,		
		PageNotFoundComponent,
		CapitalizeFirstPipe
	],
	imports: [
		BrowserModule,
		FormsModule,
		ReactiveFormsModule,
		AppRoutingModule,
		HttpModule,
		PipeModule,
		BreadcrumbModule,
		MessageModule

	],
	providers: [
		ErrorHandlerService,
		MapService,
		ListsService,
		{ provide: LOCALE_ID, useValue: "nl-NL" }
	],
	bootstrap: [AppComponent]
})
export class AppModule {
	constructor(private router: Router, private messageService: MessageService) {
		router.events.subscribe((event) => {
			if (event) {
				if (event instanceof NavigationEnd) {
					this.messageService.removeAllMessages();
				}
			}
		});
	}
}

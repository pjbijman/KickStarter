import { Component } from "@angular/core";
import { MessageService } from "./message.service";
import { BehaviorSubject } from "rxjs/BehaviorSubject";
import { Subject } from "rxjs/Subject";

@Component({
	selector: "messages",
	templateUrl: "message.component.html",
	styles: [
		`
    alert{font-size:15px;}
  `
	],
})
export class MessageComponent {
	lastObserver: Subject<boolean> = new BehaviorSubject(false);
	private lastAmountMessages = 0;

	constructor(public messageService: MessageService) {
	}

	/**
	    * Remove message
	    * @constructor
	    * @param {number} i - Index        
	*/
	closeMessage(i: number): void {
		this.messageService.removeMessage(i);
	}
}

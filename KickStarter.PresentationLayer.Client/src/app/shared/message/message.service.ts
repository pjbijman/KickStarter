import { Message } from "./message.model";

export class MessageService {
	messages: Message[] = [];

	/**
	    * Add message
	    * @constructor
	    * @param {string} message - Message
	    * @param {string} type - Type
	*/
	addMessage(message: string): void;
	addMessage(message: string, type: string): void;
	addMessage(message: string, type?: string): void {
		const na = new Message();
		na.message = message;
		na.type = type || "info";

		this.messages.push(na);

		window.scrollTo(0, 0);
	}

	/**
	    * Remove specific message
	    * @constructor
	    * @param {number} index - Index
	*/
	removeMessage(index: number): void {
		this.messages.splice(index, 1);
	}

	/** Remove all messages */
	removeAllMessages(): void {
		this.messages = [];
	}
}

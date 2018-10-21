//implemented according to: http://www.dustinhorne.com/post/2016/06/09/implementing-a-dictionary-in-typescript

export class Dictionary<T> {
	private items: { [key: string]: T } = {};
	private count = 0;

	ContainsKey(key: string): boolean {
		return this.items.hasOwnProperty(key);
	}

	Count(): number {
		return this.count;
	}

	AddOrSet(key: string, value: T) {
		if (!this.ContainsKey(key))
			this.count++;
		this.items[key] = value;
	}

	Remove(key: string): T {
		const val = this.items[key];
		if (!this.ContainsKey(key))
			return val;
		this.count--;
		delete this.items[key];
		return val;
	}

	Item(key: string) {
		return this.items[key];
	}

	Keys(): string[] {
		return Object.keys(this.items);
	}

	Values(): T[] {
		const keys = this.Keys();
		const values: T[] = [];
		for (let i = 0; i < keys.length; i++)
			values.push(this.items[keys[i]]);
		return values;
	}
}

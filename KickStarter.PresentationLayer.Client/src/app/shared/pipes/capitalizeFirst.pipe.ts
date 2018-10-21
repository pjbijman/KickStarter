
/* kindly provided by chl03ks
 source: https://gist.github.com/chl03ks/c7fbd8b7f632f5891e98854b024f0557 */



import { Pipe, PipeTransform } from '@angular/core';
/*
 * Capitalize the first letter of the string
 * Takes a string as a value.
 * Usage:
 *  value | capitalizefirst
 * Example:
 *  // value.name = daniel
 *  {{ value.name | capitalizefirst  }}
 *  fromats to: Daniel
*/
@Pipe({
	name: 'capitalizeFirst'
})
export class CapitalizeFirstPipe implements PipeTransform {
	transform(value: string, args: any[]): string {
		if (value === null) return 'Not assigned';
		return value.charAt(0).toUpperCase() + value.slice(1);
	}
}

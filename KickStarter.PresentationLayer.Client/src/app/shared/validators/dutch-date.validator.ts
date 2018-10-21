import { ValidatorFn, AbstractControl } from "@angular/forms";

/**
 * Validate dutch date
 */
export function DutchDateValidator(): ValidatorFn {
	return (control: AbstractControl): { [key: string]: any } => {
		if (control.value) {
			const regularExpression = /^\d{1,2}\-\d{1,2}\-\d{4}$/;
			const validInput = regularExpression.test(control.value);

			let validDate = false;
			if (validInput) {
				const parts = control.value.split("-");

				// validate date
				const month = Number(parts[1]);
				const day = Number(parts[0]);
				const year = Number(parts[2]);

				switch (month) {
				case 1:
				case 3:
				case 5:
				case 7:
				case 8:
				case 10:
				case 12:
					validDate = day <= 31;
					break;
				case 4:
				case 6:
				case 9:
				case 11:
					validDate = day <= 30;
					break;
				case 2:
					//Determine if leap year
					const isLeapYear = ((year % 4 == 0) && (year % 100 != 0)) || (year % 400 == 0);

					validDate = (isLeapYear && day <= 29) || (!isLeapYear && day <= 28);
					break;
				default:
					validDate = false;
					break;
				}

				if (validDate) {
					validDate = day > 0 && month > 0 && year > 0;
				}
			}

			return !validDate ? { 'dutchDate': { validDate } } : null;
		}
	};
}

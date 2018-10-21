

export class PriceUnitSemantic {

	static nlNL_sem: string[] =
	[
		"Stuk",
		"Kilometer",
		"Minuten",
		"Liter"
	];

	/**
	 * Convert PriceUnit to a semantic string.
	 * See also PriceUnitType.cs
	 * @param factor
	 */
	static convert(priceUnit: number): string {
		return this.nlNL_sem[priceUnit];
	}

}



export class TimeFactorSemantic {

	static nlNL_sem: string[] =
	[
		"evenement",
		"evenementdag",
		"dag",
		"halve dag",
		"uur",
		//"minuut"
	];

	static nlNL_sem_plural: string[] =
	[
		"evenement",
		"evenementdagen",
		"dagen",
		"halve dagen",
		"uur",
		//"minuten"
	];

	/**
	 * Convert timeFactor to a semantic string.
	 * See also TimeFactorType.cs
	 * @param factor
	 */
	static convert(factor: number): string {
		return this.nlNL_sem[factor];
	}

}

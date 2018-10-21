

export class LifeguardBrigadeLevelSemantic {

	static nlNL_sem: string[] =
	[
		"Landelijk",
		"Veiligheidsregio",
		"Brigade"
	];

	/**
	 * Convert Lifeguard Brigade Level to a semantic string.
	 * See also BrigadeLevelType.cs
	 * @param lbl
	 */
	static convert(lbl: number): string {
		return this.nlNL_sem[lbl];
	}

}

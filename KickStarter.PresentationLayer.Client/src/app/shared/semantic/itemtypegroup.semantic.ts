

export class ItemTypeGroupSemantic {

	static nlNL_sem: string[] =
	[
		"materiaalkosten",
		"bemanningskosten",
		"overige kosten"
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

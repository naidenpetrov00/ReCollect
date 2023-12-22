namespace PackIT.Domain.Policies.Gender
{
	using System.Collections.Generic;

	internal sealed class FemaleGenderPolicy : IPackingItemsPolicy
	{
		public bool IsApplicable(PolicyData data)
			=> data.Gender is Enums.Gender.Female;

		public IEnumerable<PackingItem> GenerateItems(PolicyData data)
			=> new List<PackingItem>
			{
				new ("Lipstick", 1),
				new ("Powder", 1),
				new ("Eyeliner", 1),
			};
	}
}
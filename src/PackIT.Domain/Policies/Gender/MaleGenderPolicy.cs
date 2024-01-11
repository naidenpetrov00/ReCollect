using PackIT.Domain.ValueObjects.PackingItems;

namespace PackIT.Domain.Policies.Gender
{
	internal class MaleGenderPolicy : IPackingItemsPolicy
	{
		public IEnumerable<PackingItem> GenerateItems(PolicyData data)
		=> new List<PackingItem>
		{
			new PackingItem{Name="Laptop", Quantity=1 },
			new PackingItem{Name = "Beer", Quantity = 10 },
			new PackingItem{Name = "Book", Quantity = (uint)Math.Ceiling(data.Days / 7m)},
		};

		public bool IsApplicable(PolicyData data)
			=> data.Gender is Enums.Gender.Male;
	}
}

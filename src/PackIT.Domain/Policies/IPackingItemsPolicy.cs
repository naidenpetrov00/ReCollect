namespace PackIT.Domain.Policies
{
	using PackIT.Domain.ValueObjects.PackingItems;

	public interface IPackingItemsPolicy
	{
		bool IsApplicable(PolicyData data);

		IEnumerable<PackingItem> GenerateItems(PolicyData data);
	}
}

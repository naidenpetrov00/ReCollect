namespace PackIT.Domain.Policies
{
	using PackIT.Domain.ValueObjects;

	public interface IPackingItemsPolicy
	{
		bool IsApplicable(PolicyData data);

		IEnumerable<PackingItem> GenerateItems(PolicyData data);
	}
}

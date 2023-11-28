namespace PackIT.Domain.Factory
{
	using PackIT.Domain.Entities;
	using PackIT.Domain.Enums;
	using PackIT.Domain.ValueObjects;

	public interface IPackingListFactory
	{
		PackingList CreatePackingList(PackingListId id, PackingListName name, Localization localization);

		PackingList CreatePackingListWithDefaultItems(
			PackingListId id,
			PackingListName name,
			Localization localization,
			TravelDays days,
			Temperature temperature,
			Gender gender);
	}
}

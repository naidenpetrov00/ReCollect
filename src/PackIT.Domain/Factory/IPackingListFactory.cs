namespace PackIT.Domain.Factory
{
    using PackIT.Domain.AggregatesModel.PackingAggregate.Entities;
    using PackIT.Domain.Enums;
    using PackIT.Domain.ValueObjects;
    using PackIT.Domain.ValueObjects.PackingLists;

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

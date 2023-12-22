namespace PackIT.Domain.Events
{
    using PackIT.Domain.Common;
    using PackIT.Domain.Entities;
	using PackIT.Domain.ValueObjects.PackingItems;

	internal record PackingItemUnpacked(PackingList packingList, PackingItem item) : IDomainEvent;
}
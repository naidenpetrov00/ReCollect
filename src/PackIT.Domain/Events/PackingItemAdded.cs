namespace PackIT.Domain.Events
{
    using PackIT.Domain.Common;
    using PackIT.Domain.Entities;
	using PackIT.Domain.ValueObjects.PackingItems;

	public record PackingItemAdded(PackingList packingList, PackingItem packingItem) : IDomainEvent;
}

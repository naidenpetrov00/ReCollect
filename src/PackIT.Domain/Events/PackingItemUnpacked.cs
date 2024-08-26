namespace PackIT.Domain.Events;

using PackIT.Domain.AggregatesModel.PackingAggregate.Entities;
using PackIT.Domain.ValueObjects.PackingItems;

public record PackingItemUnpacked(PackingList packingList, PackingItem item) : BaseEvent;

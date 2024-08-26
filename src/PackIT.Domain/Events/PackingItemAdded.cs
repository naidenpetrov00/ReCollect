namespace PackIT.Domain.Events;

using PackIT.Domain.AggregatesModel.PackingAggregate.Entities;
using PackIT.Domain.ValueObjects.PackingItems;

public record PackingItemAdded(PackingList packingList, PackingItem packingItem) : BaseEvent;

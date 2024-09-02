namespace PackIT.Domain.Events;

using PackIT.Domain.AggregatesModel.PackingAggregate.Entities;

public record PackingItemAdded(PackingList packingList, PackingItem packingItem) : BaseEvent;

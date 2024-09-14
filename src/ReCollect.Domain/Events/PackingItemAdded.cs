namespace ReCollect.Domain.Events;

using ReCollect.Domain.AggregatesModel.PackingAggregate.Entities;

public record PackingItemAdded(PackingList packingList, PackingItem packingItem) : BaseEvent;

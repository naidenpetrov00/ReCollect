namespace ReCollect.Domain.Events;

using ReCollect.Domain.AggregatesModel.PackingAggregate.Entities;

public record PackingItemPacked(PackingList packingList, PackingItem packingItem) : BaseEvent;

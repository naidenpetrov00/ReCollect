namespace ReCollect.Domain.Events;

using ReCollect.Domain.AggregatesModel.PackingAggregate.Entities;

public record PackingItemUnpacked(PackingList packingList, PackingItem item) : BaseEvent;

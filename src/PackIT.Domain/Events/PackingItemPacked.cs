namespace PackIT.Domain.Events;

using PackIT.Domain.AggregatesModel.PackingAggregate.Entities;

public record PackingItemPacked(PackingList packingList, PackingItem packingItem) : BaseEvent;

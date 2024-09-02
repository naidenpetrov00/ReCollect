namespace PackIT.Domain.Events;

using PackIT.Domain.AggregatesModel.PackingAggregate.Entities;

public record PackingItemUnpacked(PackingList packingList, PackingItem item) : BaseEvent;

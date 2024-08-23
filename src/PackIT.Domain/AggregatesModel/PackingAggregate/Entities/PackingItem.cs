using PackIT.Domain.AggregatesModel.PackingAggregate.Entities;
using PackIT.Domain.SeedWork;

namespace PackIT.Domain.ValueObjects.PackingItems;

public class PackingItem : BaseAuditableEntity
{
    public PackingItemName? Name { get; set; }
    public uint Quantity { get; set; }
    public bool IsPacked { get; set; }

    public PackingList PackingList { get; set; } = null!;
}

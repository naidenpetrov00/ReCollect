namespace ReCollect.Domain.AggregatesModel.PackingAggregate.Entities;

public class PackingItem : BaseAuditableEntity
{
    public PackingItemName? Name { get; set; }
    public uint Quantity { get; set; }
    public bool IsPacked { get; set; }

    public PackingList PackingList { get; set; } = null!;
}

namespace ReCollect.Domain.Policies;

using ReCollect.Domain.AggregatesModel.PackingAggregate.Entities;

public interface IPackingItemsPolicy
{
    bool IsApplicable(PolicyData data);

    IEnumerable<PackingItem> GenerateItems(PolicyData data);
}

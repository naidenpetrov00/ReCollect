namespace PackIT.Domain.Policies;

using PackIT.Domain.AggregatesModel.PackingAggregate.Entities;

public interface IPackingItemsPolicy
{
    bool IsApplicable(PolicyData data);

    IEnumerable<PackingItem> GenerateItems(PolicyData data);
}

namespace ReCollect.Domain.Policies.Gender;

using ReCollect.Domain.AggregatesModel.PackingAggregate.Entities;
using ReCollect.Domain.AggregatesModel.PackingAggregate.ValueObjects;

internal class MaleGenderPolicy : IPackingItemsPolicy
{
    public IEnumerable<PackingItem> GenerateItems(PolicyData data) =>
        [
            new() { Name = (PackingItemName)"Laptop", Quantity = 1 },
            new() { Name = (PackingItemName)"Beer", Quantity = 10 },
            new() { Name = (PackingItemName)"Book", Quantity = (uint)Math.Ceiling(data.Days / 7m) },
        ];

    public bool IsApplicable(PolicyData data) => data.Gender is Enums.Gender.Male;
}

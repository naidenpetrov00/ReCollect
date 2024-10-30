namespace ReCollect.Domain.Policies.Gender;

using System.Collections.Generic;
using ReCollect.Domain.AggregatesModel.PackingAggregate.Entities;
using ReCollect.Domain.AggregatesModel.PackingAggregate.ValueObjects;

internal sealed class FemaleGenderPolicy : IPackingItemsPolicy
{
    public bool IsApplicable(PolicyData data) => data.Gender is Enums.Gender.Female;

    public IEnumerable<PackingItem> GenerateItems(PolicyData data) =>
        [
            new() { Name = (PackingItemName)"Lipstick", Quantity = 1 },
            new() { Name = (PackingItemName)"Powder", Quantity = 1 },
            new() { Name = (PackingItemName)"Eyeliner", Quantity = 1 },
        ];
}

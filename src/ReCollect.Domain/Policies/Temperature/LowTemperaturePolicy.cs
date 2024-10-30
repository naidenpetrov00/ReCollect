namespace ReCollect.Domain.Policies.Temperature;

using System.Collections.Generic;
using ReCollect.Domain.AggregatesModel.PackingAggregate.Entities;
using ReCollect.Domain.AggregatesModel.PackingAggregate.ValueObjects;

internal sealed class LowTemperaturePolicy : IPackingItemsPolicy
{
    public bool IsApplicable(PolicyData data) => data.Temperature < 10D;

    public IEnumerable<PackingItem> GenerateItems(PolicyData data) =>
        new List<PackingItem>
        {
            new PackingItem { Name = (PackingItemName)"Winter hat", Quantity = 1 },
            new PackingItem { Name = (PackingItemName)"Scarf", Quantity = 1 },
            new PackingItem { Name = (PackingItemName)"Gloves", Quantity = 1 },
            new PackingItem { Name = (PackingItemName)"Hoodie", Quantity = 1 },
            new PackingItem { Name = (PackingItemName)"Warm jacket", Quantity = 1 },
        };
}

namespace ReCollect.Domain.Policies.Temperature;

using System.Collections.Generic;
using ReCollect.Domain.AggregatesModel.PackingAggregate.Entities;

internal sealed class LowTemperaturePolicy : IPackingItemsPolicy
{
    public bool IsApplicable(PolicyData data) => data.Temperature < 10D;

    public IEnumerable<PackingItem> GenerateItems(PolicyData data) =>
        new List<PackingItem>
        {
            new PackingItem { Name = "Winter hat", Quantity = 1 },
            new PackingItem { Name = "Scarf", Quantity = 1 },
            new PackingItem { Name = "Gloves", Quantity = 1 },
            new PackingItem { Name = "Hoodie", Quantity = 1 },
            new PackingItem { Name = "Warm jacket", Quantity = 1 },
        };
}

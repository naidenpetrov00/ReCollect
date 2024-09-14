namespace ReCollect.Domain.Policies.Temperature;

using System.Collections.Generic;
using ReCollect.Domain.AggregatesModel.PackingAggregate.Entities;

internal sealed class HighTemperaturePolicy : IPackingItemsPolicy
{
    public bool IsApplicable(PolicyData data) => data.Temperature > 25D;

    public IEnumerable<PackingItem> GenerateItems(PolicyData data) =>
        new List<PackingItem>
        {
            new PackingItem { Name = "Hat", Quantity = 1 },
            new PackingItem { Name = "Sunglasses", Quantity = 1 },
            new PackingItem { Name = "Cream with UV filter", Quantity = 1 },
        };
}

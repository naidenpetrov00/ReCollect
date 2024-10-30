namespace ReCollect.Domain.Policies.Temperature;

using System.Collections.Generic;
using ReCollect.Domain.AggregatesModel.PackingAggregate.Entities;
using ReCollect.Domain.AggregatesModel.PackingAggregate.ValueObjects;

internal sealed class HighTemperaturePolicy : IPackingItemsPolicy
{
    public bool IsApplicable(PolicyData data) => data.Temperature > 25D;

    public IEnumerable<PackingItem> GenerateItems(PolicyData data) =>
        new List<PackingItem>
        {
            new() { Name = (PackingItemName)"Hat", Quantity = 1 },
            new() { Name = (PackingItemName)"Sunglasses", Quantity = 1 },
            new() { Name = (PackingItemName)"Cream with UV filter", Quantity = 1 },
        };
}

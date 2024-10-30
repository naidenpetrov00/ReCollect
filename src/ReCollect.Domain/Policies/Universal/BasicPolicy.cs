namespace ReCollect.Domain.Policies.Universal;

using System;
using System.Collections.Generic;
using ReCollect.Domain.AggregatesModel.PackingAggregate.Entities;
using ReCollect.Domain.AggregatesModel.PackingAggregate.ValueObjects;


internal sealed class BasicPolicy : IPackingItemsPolicy
{
    private const uint MaximumQuantityOfClothes = 7;

    public bool IsApplicable(PolicyData _) => true;

    public IEnumerable<PackingItem> GenerateItems(PolicyData data) =>
        new List<PackingItem>
        {
            new() {
                Name = (PackingItemName)"Pants",
                Quantity = Math.Min(data.Days, MaximumQuantityOfClothes),
            },
            new() {
                Name = (PackingItemName)"Socks",
                Quantity = Math.Min(data.Days, MaximumQuantityOfClothes),
            },
            new() {
                Name = (PackingItemName)"T-Shirt",
                Quantity = Math.Min(data.Days, MaximumQuantityOfClothes),
            },
            new() { Name = (PackingItemName)"Trousers", Quantity = data.Days < 7 ? 1u : 2u },
            new() { Name = (PackingItemName)"Shampoo", Quantity = 1 },
            new() { Name = (PackingItemName)"Toothbrush", Quantity = 1 },
            new() { Name = (PackingItemName)"Toothpaste", Quantity = 1 },
            new() { Name = (PackingItemName)"Towel", Quantity = 1 },
            new() { Name = (PackingItemName)"Bag pack", Quantity = 1 },
            new() { Name = (PackingItemName)"Passport", Quantity = 1 },
            new() { Name = (PackingItemName)"Phone Charger", Quantity = 1 },
        };
}

namespace PackIT.Domain.Policies.Universal;

using System;
using System.Collections.Generic;
using PackIT.Domain.ValueObjects.PackingItems;

internal sealed class BasicPolicy : IPackingItemsPolicy
{
    private const uint MaximumQuantityOfClothes = 7;

    public bool IsApplicable(PolicyData _) => true;

    public IEnumerable<PackingItem> GenerateItems(PolicyData data) =>
        new List<PackingItem>
        {
            new PackingItem
            {
                Name = "Pants",
                Quantity = Math.Min(data.Days, MaximumQuantityOfClothes),
            },
            new PackingItem
            {
                Name = "Socks",
                Quantity = Math.Min(data.Days, MaximumQuantityOfClothes),
            },
            new PackingItem
            {
                Name = "T-Shirt",
                Quantity = Math.Min(data.Days, MaximumQuantityOfClothes),
            },
            new PackingItem { Name = "Trousers", Quantity = data.Days < 7 ? 1u : 2u },
            new PackingItem { Name = "Shampoo", Quantity = 1 },
            new PackingItem { Name = "Toothbrush", Quantity = 1 },
            new PackingItem { Name = "Toothpaste", Quantity = 1 },
            new PackingItem { Name = "Towel", Quantity = 1 },
            new PackingItem { Name = "Bag pack", Quantity = 1 },
            new PackingItem { Name = "Passport", Quantity = 1 },
            new PackingItem { Name = "Phone Charger", Quantity = 1 },
        };
}

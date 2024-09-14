﻿namespace ReCollect.Domain.Policies.Gender;

using System.Collections.Generic;
using ReCollect.Domain.AggregatesModel.PackingAggregate.Entities;

internal sealed class FemaleGenderPolicy : IPackingItemsPolicy
{
    public bool IsApplicable(PolicyData data) => data.Gender is Enums.Gender.Female;

    public IEnumerable<PackingItem> GenerateItems(PolicyData data) =>
        new List<PackingItem>
        {
            new PackingItem { Name = "Lipstick", Quantity = 1 },
            new PackingItem { Name = "Powder", Quantity = 1 },
            new PackingItem { Name = "Eyeliner", Quantity = 1 },
        };
}

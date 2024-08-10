﻿namespace PackIT.Domain.AggregatesModel.PackingAggregate.Entities
{
    using System.Collections.Generic;
    using Ardalis.GuardClauses;
    using PackIT.Domain.Events;
    using PackIT.Domain.SeedWork;
    using PackIT.Domain.ValueObjects.PackingItems;
    using PackIT.Domain.ValueObjects.PackingLists;

    public class PackingList : BaseAuditableEntity<int>, IAgregateRoot
    {
        private readonly List<PackingItem> packingItems;

        public PackingListName Name { get; private set; }

        public Localization Localization { get; private set; }

        public IReadOnlyCollection<PackingItem> PackingItems => this.packingItems.AsReadOnly();

        public void AddItem(PackingItem item)
        {
            Guard.Against.Null(item);
            Guard.Against.InvalidInput(
                item,
                nameof(item),
                i => this.packingItems.Contains(i),
                $"Packing item '{item.Name?.Value}' already exists."
            );

            this.packingItems.Add(item);
            this.AddDomainEvent(new PackingItemAdded(this, item));
        }

        public void AddItems(IEnumerable<PackingItem> items)
        {
            foreach (PackingItem item in items)
            {
                AddItem(item);
            }
        }

        public void PackItem(string itemName)
        {
            var item = GetItem(itemName);
            Guard.Against.Null(item);
            item.IsPacked = true;

            this.AddDomainEvent(new PackingItemPacked(this, item));
        }

        public void UnpackItem(string itemName)
        {
            var item = GetItem(itemName);
            this.packingItems.Remove(item);

            this.AddDomainEvent(new PackingItemUnpacked(this, item));
        }

        private PackingItem GetItem(string itemName)
        {
            var item = this.packingItems.SingleOrDefault(i => i.Name == itemName);
            Guard.Against.Null(item);

            return item;
        }
    }
}
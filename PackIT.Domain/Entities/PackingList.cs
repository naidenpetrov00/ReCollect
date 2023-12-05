namespace PackIT.Domain.Entities
{
	using System.Collections.Generic;
	using PackIT.Domain.Common;
	using PackIT.Domain.Events;
	using PackIT.Domain.Exceptions;
	using PackIT.Domain.ValueObjects;

	public class PackingList : BaseEntity<PackingListId>
	{
		private readonly LinkedList<PackingItem> items = new LinkedList<PackingItem>();
		private PackingListName name;
		private Localization localization;

		internal PackingList(PackingListId id, PackingListName name, Localization localization)
		{
			this.Id = id;
			this.name = name;
			this.localization = localization;
		}

		private PackingList(PackingListId id, PackingListName name, Localization localization, LinkedList<PackingItem> items)
			: this(id, name, localization)
		{
			this.AddItems(items);
		}

		public PackingListId Id { get; private set; }

		public void AddItem(PackingItem item)
		{
			if (this.items.Contains(item))
			{
				throw new PackingItemExists(this.name, item.Name);
			}

			this.items.AddLast(item);

			this.AddEvent(new PackingItemAdded(this, item));
		}

		public void AddItems(IEnumerable<PackingItem> items)
		{
			foreach (PackingItem item in items)
			{
				this.AddItem(item);
			}
		}

		public void PackItem(string itemName)
		{
			var item = this.GetItem(itemName);
			var packedItem = item with { IsPacked = true };

			this.items.Find(item).Value = packedItem;

			this.AddEvent(new PackingItemPacked(this, item));
		}

		public void UnpackItem(string itemName)
		{
			var item = this.GetItem(itemName);
			this.items.Remove(item);

			this.AddEvent(new PackingItemUnpacked(this, item));
		}

		private PackingItem GetItem(string itemName)
		{
			var item = this.items.SingleOrDefault(item => item.Name == itemName);
			if (item is null)
			{
				throw new PackingItemNotFound(itemName);
			}

			return item;
		}
	}
}

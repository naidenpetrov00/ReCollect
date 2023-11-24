namespace PackIT.Domain.Entities
{
	using PackIT.Domain.Common;
	using PackIT.Domain.Events;
	using PackIT.Domain.Exceptions;
	using PackIT.Domain.ValueObjects;

	public class PackingList : BaseEntity<PackingListId>
	{
		private PackingListName _name;
		private Localization _localization;
		private readonly LinkedList<PackingItem> _items = new();

		public PackingListId ListId { get; private set; }

		internal PackingList(PackingListId id, PackingListName name, Localization localization)
		{
			this.ListId = id;
			this._name = name;
			this._localization = localization;
		}
		private PackingList(PackingListId id, PackingListName name, Localization localization, LinkedList<PackingItem> items)
			: this(id, name, localization)
		{
			this.AddItems(items);
		}

		private PackingItem GetItem(string itemName)
		{
			var item = this._items.SingleOrDefault(item => item.Name == itemName);
			if (item is null)
			{
				throw new PackingItemNotFound(itemName);
			}

			return item;
		}

		public void AddItem(PackingItem item)
		{
			if (this._items.Contains(item))
			{
				throw new PackingItemExists(this._name, item.Name);
			}

			this._items.AddLast(item);

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

			this._items.Find(item).Value = packedItem;

			AddEvent(new PackingItemPacked(this, item));
		}

		public void UnpackItem(string itemName)
		{
			var item = this.GetItem(itemName);
			this._items.Remove(item);

			AddEvent(new PackingItemUnpacked(this, item));
		}
	}
}

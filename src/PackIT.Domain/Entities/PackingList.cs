namespace PackIT.Domain.Entities
{
	using Ardalis.GuardClauses;
	using PackIT.Domain.Common;
	using PackIT.Domain.Events;
	using PackIT.Domain.Exceptions;
	using PackIT.Domain.ValueObjects.PackingItems;
	using PackIT.Domain.ValueObjects.PackingLists;

	using System.Collections.Generic;

	public class PackingList : BaseAuditableEntity<PackingListId>
	{
		public PackingListId Id { get; set; }

		public PackingListName Name { get; set; }

		public Localization Localization { get; set; }

		public LinkedList<PackingItem> Items
			=> new LinkedList<PackingItem>();

		public void AddItem(PackingItem item)
		{
			if (this.Items.Contains(item))
			{
				throw new PackingItemExistsException(this.Name, item.Name);
			}

			this.Items.AddLast(item);

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


			this.Items.Find(item).Value = packedItem;

			this.AddEvent(new PackingItemPacked(this, item));
		}

		public void UnpackItem(string itemName)
		{
			var item = this.GetItem(itemName);
			this.Items.Remove(item);

			this.AddEvent(new PackingItemUnpacked(this, item));
		}

		private PackingItem GetItem(string itemName)
		{
			var item = this.Items.SingleOrDefault(item => item.Name == itemName);
			Guard.Against.Null(item);

			return item;
		}
	}
}

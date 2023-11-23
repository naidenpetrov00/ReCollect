using PackIT.Domain.Exceptions;
using PackIT.Domain.ValueObjects;

namespace PackIT.Domain.Entities
{
	public class PackingList
	{
		private PackingListName _name;
		private Localization _localization;
		private readonly LinkedList<PackingItem> _items = new();

		public Guid Id { get; private set; }

		internal PackingList(Guid id, PackingListName name, Localization localization, LinkedList<PackingItem> items)
		{
			this.Id = id;
			this._name = name;
			this._localization = localization;
			_items = items;
		}

		public void AddItem(PackingItem item)
		{
			if (this._items.Contains(item))
			{
				throw new PackingItemExists(this._name, item.Name);
			}

			this._items.AddLast(item);
		}
	}
}

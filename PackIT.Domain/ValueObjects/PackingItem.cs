namespace PackIT.Domain.ValueObjects
{
	using PackIT.Domain.Exceptions;

	public record PackingItem
	{
		public string Name { get; }
		public uint Quantity { get; }
		public bool IsPacked { get; }

		public PackingItem(string name, uint quantity, bool isPacked)
		{
			if (string.IsNullOrWhiteSpace(name))
			{
				throw new EmptyPackingListItemNameException();
			}

			this.Name = name;
			this.Quantity = quantity;
			this.IsPacked = isPacked;
		}
	}
}

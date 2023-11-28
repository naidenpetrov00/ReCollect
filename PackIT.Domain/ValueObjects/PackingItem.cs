namespace PackIT.Domain.ValueObjects
{
	using PackIT.Domain.Exceptions;

	public record PackingItem
	{
		public string Name { get; }
		public uint Quantity { get; }
		public bool IsPacked { get; init; }

		public PackingItem(string name, uint quantity, bool isPacked = false)
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

namespace PackIT.Domain.ValueObjects.PackingItems
{
	using PackIT.Domain.Exceptions;

	public class PackingItemName
	{
		public PackingItemName(string value)
		{
			if (string.IsNullOrWhiteSpace(value))
			{
				throw new EmptyPackingListItemNameException();
			}

			this.Value = value;
		}

		public string Value { get; private set; }

		public static implicit operator string(PackingItemName packingItemName)
			=> packingItemName.Value;

		public static implicit operator PackingItemName(string value)
			=> new PackingItemName(value);
	}

}

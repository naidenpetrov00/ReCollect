namespace PackIT.Domain.ValueObjects.PackingItems
{
	public record PackingItem
	{
		public PackingItemName Name { get; set; }
		public uint Quantity { get; set; }
		public bool IsPacked { get; set; }
	}
}

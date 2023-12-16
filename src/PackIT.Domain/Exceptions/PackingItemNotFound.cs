namespace PackIT.Domain.Exceptions
{
	public class PackingItemNotFound : Exception
	{

		public PackingItemNotFound(string itemName)
			: base($"Packing item '{itemName}' was not found")
			=> this.ItemName = itemName;

		public string ItemName { get; }
	}
}
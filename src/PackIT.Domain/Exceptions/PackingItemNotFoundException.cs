namespace PackIT.Domain.Exceptions
{
	public class PackingItemNotFoundException : Exception
	{

		public PackingItemNotFoundException(string itemName)
			: base($"Packing item '{itemName}' was not found")
			=> this.ItemName = itemName;

		public string ItemName { get; }
	}
}
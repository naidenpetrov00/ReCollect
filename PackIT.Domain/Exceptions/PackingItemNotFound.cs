using System.Runtime.Serialization;

namespace PackIT.Domain.Exceptions
{
	[Serializable]
	internal class PackingItemNotFound : Exception
	{

		public PackingItemNotFound(string itemName)
			: base($"Packing item '{itemName}' was not found")
			=> this.ItemName = itemName;

		public string ItemName { get; }
	}
}
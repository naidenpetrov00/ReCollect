namespace PackIT.Domain.Exceptions
{
	public class PackingItemExists : Exception
	{
        public PackingItemExists(string listName, string itemName)
            :base($"Packing list: '${listName}' already defined item: '${itemName}'") { }
    }
}

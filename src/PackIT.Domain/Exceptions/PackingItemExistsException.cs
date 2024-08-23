namespace PackIT.Domain.Exceptions;

public class PackingItemExistsException : Exception
{
    public PackingItemExistsException(string listName, string itemName)
        : base($"Packing list: '${listName}' already defined item: '${itemName}'") { }
}

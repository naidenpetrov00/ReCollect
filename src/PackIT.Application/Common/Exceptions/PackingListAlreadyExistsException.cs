namespace PackIT.Application.Common.Exceptions
{
    public class PackingListAlreadyExistsException : Exception
    {
        public PackingListAlreadyExistsException(string? name)
            : base($"Packing list: '{name}' already exists.")
        {
        }
    }
}
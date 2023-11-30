namespace PackIT.Application.Exceptions
{
	internal class PackingListAlreadyExistsException : Exception
	{
		public PackingListAlreadyExistsException(string? name)
			: base($"Packing list: '{name}' already exists.")
		{
		}
	}
}
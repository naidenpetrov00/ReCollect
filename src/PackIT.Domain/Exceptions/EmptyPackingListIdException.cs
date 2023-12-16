namespace PackIT.Domain.Exceptions
{
	internal class EmptyPackingListIdException : Exception
	{
		public EmptyPackingListIdException()
			: base("Packing list ID cannot be empty")
        {
        }
	}
}
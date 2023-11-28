namespace PackIT.Domain.Exceptions
{
	internal class EmptyPackingListIdException : Exception
	{
		public EmptyPackingListIdException()
			: base("Packing list id cannot be empty")
        {
        }
	}
}
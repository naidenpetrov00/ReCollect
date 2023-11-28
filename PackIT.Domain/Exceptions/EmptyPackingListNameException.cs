namespace PackIT.Domain.Exceptions
{
	public class EmptyPackingListNameException : Exception
	{
		public EmptyPackingListNameException()
			: base("packing list name cannot be empty.")
        {
        }
	}
}

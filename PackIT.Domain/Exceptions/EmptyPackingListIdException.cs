using System.Runtime.Serialization;

namespace PackIT.Domain.Exceptions
{
	[Serializable]
	internal class EmptyPackingListIdException : Exception
	{

		public EmptyPackingListIdException()
			: base("Packing list id cannot be empty") { }
	}
}
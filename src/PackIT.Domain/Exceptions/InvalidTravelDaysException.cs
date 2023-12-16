namespace PackIT.Domain.Exceptions
{
	public class InvalidTravelDaysException : Exception
	{
		public InvalidTravelDaysException(ushort days)
			: base($"Value '${days}' is invalid travel days.")
        {
        }
	}
}
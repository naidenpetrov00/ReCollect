namespace PackIT.Domain.Exceptions
{
	internal class InvalidTemperatureException : Exception
	{
		public InvalidTemperatureException(double temperature)
			: base($"Temperature '${temperature}' is in invalid range")
        {
        }
	}
}
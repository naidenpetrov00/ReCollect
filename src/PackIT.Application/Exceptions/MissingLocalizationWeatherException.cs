namespace PackIT.Application.Exceptions
{
	using PackIT.Domain.ValueObjects;

	public class MissingLocalizationWeatherException : Exception
	{
		public MissingLocalizationWeatherException(Localization localization)
			: base($"Couldnt't fetch weather data for '{localization.Country}/{localization.City}'")
		{
		}
	}
}
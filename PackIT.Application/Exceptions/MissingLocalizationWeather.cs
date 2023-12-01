namespace PackIT.Application.Exceptions
{
	using PackIT.Domain.ValueObjects;

	public class MissingLocalizationWeather : Exception
	{
		public MissingLocalizationWeather(Localization localization)
			: base($"Couldnt't fetch weather data for '{localization.Country}/{localization.City}'")
		{
		}
	}
}
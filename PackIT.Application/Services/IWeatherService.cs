namespace PackIT.Application.Services
{
	using PackIT.Domain.ValueObjects;

	public interface IWeatherService
	{
		Task<> GetWeatherAsync(Localization localization);
	}
}

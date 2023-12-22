namespace PackIT.Application.Services
{
    using PackIT.Application.DTO.External;
    using PackIT.Domain.ValueObjects.PackingLists;

    public interface IWeatherService
	{
		Task<WeatherDto> GetWeatherAsync(Localization localization);
	}
}

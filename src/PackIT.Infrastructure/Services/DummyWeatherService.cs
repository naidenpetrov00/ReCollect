namespace PackIT.Infrastructure.Services
{
    using PackIT.Application.DTO.External;
    using PackIT.Application.Services;
    using PackIT.Domain.ValueObjects.PackingLists;

    internal sealed class DummyWeatherService : IWeatherService
	{
		public Task<WeatherDto> GetWeatherAsync(Localization localization)
		=> Task.FromResult(new WeatherDto(new Random().Next(-15, 35)));
	}
}

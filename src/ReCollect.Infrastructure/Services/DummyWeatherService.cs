namespace ReCollect.Infrastructure.Services;

using ReCollect.Application.Common.DTO.External;
using ReCollect.Application.Services;
using ReCollect.Domain.ValueObjects.PackingLists;

internal sealed class DummyWeatherService : IWeatherService
{
    public Task<WeatherDto> GetWeatherAsync(Localization localization) =>
        Task.FromResult(new WeatherDto(new Random().Next(-15, 35)));
}

namespace ReCollect.Infrastructure.Services;

using ReCollect.Application.SeedWork.Models.External;
using ReCollect.Application.Services;
using ReCollect.Domain.AggregatesModel.PackingAggregate.ValueObjects;

internal sealed class DummyWeatherService : IWeatherService
{
    public Task<WeatherDto> GetWeatherAsync(Localization localization) =>
        Task.FromResult(new WeatherDto(new Random().Next(-15, 35)));
}

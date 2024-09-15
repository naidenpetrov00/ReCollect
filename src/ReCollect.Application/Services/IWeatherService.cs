namespace ReCollect.Application.Services;

using ReCollect.Application.SeedWork.Models.External;
using ReCollect.Domain.AggregatesModel.PackingAggregate.ValueObjects;

public interface IWeatherService
{
    Task<WeatherDto> GetWeatherAsync(Localization localization);
}

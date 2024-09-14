namespace ReCollect.Application.Services;

using ReCollect.Application.Common.DTO.External;
using ReCollect.Domain.ValueObjects.PackingLists;

public interface IWeatherService
{
    Task<WeatherDto> GetWeatherAsync(Localization localization);
}

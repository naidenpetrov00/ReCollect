namespace ReCollect.Application.SeedWork.Exceptions;

using ReCollect.Domain.AggregatesModel.PackingAggregate.ValueObjects;

public class MissingLocalizationWeatherException : Exception
{
    public MissingLocalizationWeatherException(Localization localization)
        : base($"Couldnt't fetch weather data for '{localization.Country}/{localization.City}'") { }
}

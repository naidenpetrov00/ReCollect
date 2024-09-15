namespace ReCollect.Domain.Policies;

using ReCollect.Domain.AggregatesModel.PackingAggregate.ValueObjects;

public record PolicyData(
    TravelDays Days,
    Enums.Gender Gender,
    AggregatesModel.PackingAggregate.ValueObjects.Temperature Temperature,
    Localization Localization
) { }

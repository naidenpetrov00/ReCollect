namespace ReCollect.Domain.Policies;

using ReCollect.Domain.ValueObjects;
using ReCollect.Domain.ValueObjects.PackingLists;

public record PolicyData(
    TravelDays Days,
    Enums.Gender Gender,
    ValueObjects.Temperature Temperature,
    Localization Localization
) { }

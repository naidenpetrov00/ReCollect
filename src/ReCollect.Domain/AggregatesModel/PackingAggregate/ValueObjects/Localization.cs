namespace ReCollect.Domain.AggregatesModel.PackingAggregate.ValueObjects;

using System.Collections.Generic;
using ReCollect.Domain.SeedWork;

public class Localization : ValueObject
{
    public Localization() { }

    public Localization(string City, string Country)
    {
        this.City = City;
        this.Country = Country;
    }

    public string City { get; }
    public string Country { get; }

    public static Localization Create(string value)
    {
        var splitLocalization = value.Split(',');
        return new Localization(splitLocalization.First(), splitLocalization.Last());
    }

    public static implicit operator string(Localization localization) =>
        $"{localization.City}, {localization.Country}";

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return City;
        yield return Country;
    }
}

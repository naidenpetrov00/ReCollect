namespace ReCollect.Domain.AggregatesModel.PackingAggregate.ValueObjects;

using System.Collections.Generic;
using ReCollect.Domain.SeedWork;

public class Localization : ValueObject
{
    public Localization() { }

    public Localization(string city, string country)
    {
        this.City = city;
        this.Country = country;
    }

    public string? City { get; }
    public string? Country { get; }

    public static Localization Create(string value)
    {
        var splitLocalization = value.Split(',');
        return new Localization(splitLocalization.First(), splitLocalization.Last());
    }

    public static implicit operator string(Localization localization) =>
        $"{localization.City}, {localization.Country}";

    protected override IEnumerable<object> GetEqualityComponents()
    {
        Guard.Against.Null(this.City);
        Guard.Against.Null(this.Country);

        yield return this.City;
        yield return this.Country;
    }
}

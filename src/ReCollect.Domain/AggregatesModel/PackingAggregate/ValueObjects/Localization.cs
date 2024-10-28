namespace ReCollect.Domain.AggregatesModel.PackingAggregate.ValueObjects;

using System.Collections.Generic;
using ReCollect.Domain.SeedWork;

public class Localization : ValueObject
{
    public Localization() { }

    public Localization(string city, string country)
    {
        Guard.Against.NullOrWhiteSpace(country, "country cannot be empty.");

        this.City = city;
        this.Country = country;
    }

    public string? City { get; private set; }
    public string? Country { get; private set; }

    public static Localization Create(string value)
    {
        var splitLocalization = value.Split(',');
        return new Localization(splitLocalization.First(), splitLocalization.Last());
    }

    public static implicit operator string(Localization localization) =>
        $"{localization.City}, {localization.Country}";

    public static explicit operator Localization(string value)
    {
        var data = value.Split(",", StringSplitOptions.RemoveEmptyEntries);
        return new Localization(data[0], data[1]);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        Guard.Against.Null(this.City);
        Guard.Against.Null(this.Country);

        yield return this.City;
        yield return this.Country;
    }
}

namespace ReCollect.Domain.ValueObjects.PackingLists;

using System.Collections.Generic;
using ReCollect.Domain.SeedWork;

public class Localization : ValueObject
{
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

    public override string ToString() => $"{City},{Country}";

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return City;
        yield return Country;
    }
}

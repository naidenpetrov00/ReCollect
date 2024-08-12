namespace PackIT.Domain.ValueObjects.PackingLists;

using System.Collections.Generic;
using PackIT.Domain.SeedWork;

public class Localization(string City, string Country) : ValueObject
{
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

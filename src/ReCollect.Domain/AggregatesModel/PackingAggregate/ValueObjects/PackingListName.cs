namespace ReCollect.Domain.AggregatesModel.PackingAggregate.ValueObjects;

using System.Collections.Generic;

public class PackingListName : ValueObject
{
#pragma warning disable CS8618
    public PackingListName() { }
#pragma warning disable CS8618

    public PackingListName(string value)
    {
        Guard.Against.NullOrWhiteSpace(value, "Packing list name cannot be empty.");

        this.Value = value;
    }

    public string Value { get; }

    protected override IEnumerable<object> GetEqualityComponents() =>
        throw new NotImplementedException();

    public static implicit operator string(PackingListName name) => name.Value;

    public static implicit operator PackingListName(string name) => new(name);
}

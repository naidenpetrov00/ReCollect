namespace ReCollect.Domain.AggregatesModel.PackingAggregate.ValueObjects;

using System.Collections.Generic;

public class PackingListName : ValueObject
{
    public PackingListName() { }

    public PackingListName(string value)
    {
        Guard.Against.NullOrWhiteSpace(value, "Packing list name cannot be empty.");

        this.Value = value;
    }

    public string? Value { get; private set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        Guard.Against.Null(this.Value);

        yield return this.Value;
    }

    public static implicit operator string(PackingListName name) => name.Value!;

    public static explicit operator PackingListName(string name) => new(name);
}

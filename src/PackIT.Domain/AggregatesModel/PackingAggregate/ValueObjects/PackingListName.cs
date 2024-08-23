namespace PackIT.Domain.ValueObjects.PackingLists;

using Ardalis.GuardClauses;
using PackIT.Domain.Exceptions;

public record PackingListName
{
    public PackingListName(string value)
    {
        Guard.Against.NullOrWhiteSpace(value, "Packing list name cannot be empty.");

        this.Value = value;
    }

    public string Value { get; }

    public static implicit operator string(PackingListName name) => name.Value;

    public static implicit operator PackingListName(string name) => new(name);
}

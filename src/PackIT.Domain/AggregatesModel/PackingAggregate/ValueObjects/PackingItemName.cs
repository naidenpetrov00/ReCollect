namespace PackIT.Domain.ValueObjects.PackingItems;

using PackIT.Domain.Exceptions;

public class PackingItemName
{
    public PackingItemName(string value)
    {
        Guard.Against.NullOrWhiteSpace(value, "Packing item name cannot be empty.");

        this.Value = value;
    }

    public string Value { get; private set; }

    public static implicit operator string(PackingItemName packingItemName) =>
        packingItemName.Value;

    public static implicit operator PackingItemName(string value) => new(value);
}

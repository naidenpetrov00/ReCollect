namespace ReCollect.Domain.AggregatesModel.PackingAggregate.ValueObjects;

using ReCollect.Domain.Exceptions;

public record TravelDays
{
    public TravelDays(ushort value)
    {
        if (value is < 0 or > 100)
            throw new InvalidTravelDaysException(value);

        this.Value = value;
    }

    public ushort Value { get; }

    public static implicit operator ushort(TravelDays temperature) => temperature.Value;

    public static implicit operator TravelDays(ushort temperature) => new(temperature);
}

namespace ReCollect.Domain.AggregatesModel.PackingAggregate.ValueObjects;

public record Temperature
{
    public Temperature(double value)
    {
        Guard.Against.OutOfRange(value, nameof(value), -100, 100);

        this.Value = value;
    }

    public double Value { get; private set; }

    public static implicit operator double(Temperature temperature) => temperature.Value;

    public static explicit operator Temperature(double value) => new(value);
}

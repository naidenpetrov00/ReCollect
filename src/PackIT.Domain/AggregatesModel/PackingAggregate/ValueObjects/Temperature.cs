namespace PackIT.Domain.ValueObjects;

using PackIT.Domain.Exceptions;

public record Temperature
{
    public Temperature(double value)
    {
        if (value is < -100 or > 100)
        {
            throw new InvalidTemperatureException(value);
        }

        this.Value = value;
    }

    public double Value { get; }

    public static implicit operator double(Temperature temperature) => temperature.Value;

    public static implicit operator Temperature(double temperature) => new(temperature);
}

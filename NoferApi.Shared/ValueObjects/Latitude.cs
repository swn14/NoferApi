namespace NoferApi.Shared.ValueObjects;

public record Latitude
{
    public double Value { get; }

    private Latitude(double value)
    {
        Value = value;
    }

    public static Latitude FromDouble(double value)
    {
        if (value < -90 || value > 90)
        {
            throw new ArgumentOutOfRangeException(nameof(value), "Latitude must be between -90 and 90 degrees.");
        }

        return new Latitude(value);
    }

    public override string ToString() => Value.ToString("F6");

    public static implicit operator double(Latitude latitude) => latitude.Value;
}

namespace NoferApi.Shared.ValueObjects;

public record Longitude
{
    public double Value { get; }

    private Longitude(double value)
    {
        Value = value;
    }

    public static Longitude FromDouble(double value)
    {
        if (value < -180 || value > 180)
        {
            throw new ArgumentOutOfRangeException(nameof(value), "Longitude must be between -180 and 180 degrees.");
        }
        return new Longitude(value);
    }

    public override string ToString() => Value.ToString("F6");

    public static implicit operator double(Longitude longitude) => longitude.Value;
}

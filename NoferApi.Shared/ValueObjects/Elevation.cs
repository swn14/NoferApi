namespace NoferApi.Shared.ValueObjects;

public record Elevation
{
    public double Value { get; }

    private Elevation(double value)
    {
        Value = value;
    }

    public static Elevation FromDouble(double value)
    {
        if (value < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(value), value, "Value must be greater than or equal to 0.");
        }

        return new Elevation(value);
    }
    
    public override string ToString() => $"{Value} ft";
    
    public static implicit operator double(Elevation elevation) => elevation.Value;
}

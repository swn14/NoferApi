namespace NoferApi.Domain.Airports.ValueObjects;

public record AirportName
{
    private const int MaxLength = 255;
    
    public string Value { get; }

    private AirportName(string value)
    {
        
    }

    public static AirportName FromString(string value)
    {
        string sanitizedValue = value.Trim();
        if (sanitizedValue.Length > MaxLength)
        {
            throw new ArgumentException($"Invalid airport name: {value}", nameof(value));
        }

        return new AirportName(sanitizedValue.Trim());
    }
}

namespace NoferApi.Domain.Airports.ValueObjects;

public record AirportGpsCode
{
    public string Value { get; }

    private AirportGpsCode(string value)
    {
        Value = value;
    }

    public static AirportGpsCode FromString(string value)
    {
        string sanitizedValue = value.Trim().Replace(" ", "");
        if (sanitizedValue.Length != 4)
        {
            throw new ArgumentException($"Invalid airport GPS code: {sanitizedValue}", nameof(value));
        }
        
        return new AirportGpsCode(sanitizedValue);
    }
}

namespace NoferApi.Domain.Airports.ValueObjects;

public record AirportIcaoCode
{
    public string Value { get; }

    private AirportIcaoCode(string value)
    {
        Value = value;
    }

    public static AirportIcaoCode FromString(string value)
    {
        string sanitizedValue = value.Trim().Replace(" ", "");
        if (sanitizedValue.Length != 4)
        {
            throw new ArgumentException($"Invalid airport ICAO code: {sanitizedValue}", nameof(value));
        }
        
        return new AirportIcaoCode(sanitizedValue);
    }
}

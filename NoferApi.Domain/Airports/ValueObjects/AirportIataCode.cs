namespace NoferApi.Domain.Airports.ValueObjects;

public record AirportIataCode
{
    public string Value { get; }

    private AirportIataCode(string value)
    {
        Value = value;
    }

    public static AirportIataCode FromString(string value)
    {
        string sanitizedValue = value.Trim().Replace(" ", "");
        if (sanitizedValue.Length != 3)
        {
            throw new ArgumentException($"Invalid airport IATA code: {sanitizedValue}", nameof(value));
        }
        
        return new AirportIataCode(sanitizedValue);
    }
}

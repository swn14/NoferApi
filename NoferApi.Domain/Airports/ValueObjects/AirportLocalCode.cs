namespace NoferApi.Domain.Airports.ValueObjects;

public record AirportLocalCode
{
    public string Value { get; }

    private AirportLocalCode(string value)
    {
        Value = value;
    }

    public static AirportLocalCode FromString(string? value)
    {
        if (value is null)
        {
            return new AirportLocalCode("");
        }
        
        string sanitizedValue = value.Trim().Replace(" ", "");
        if (sanitizedValue.Length != 3)
        {
            throw new ArgumentException($"Invalid airport local code: {sanitizedValue}", nameof(value));
        }
        
        return new AirportLocalCode(sanitizedValue);
    }
}

namespace NoferApi.Shared.ValueObjects;

public record Municipality
{
    private const int MaxLength = 100;
    
    public string Value { get; }

    private Municipality(string value)
    {
        
    }

    public static Municipality FromString(string value)
    {
        string sanitizedValue = value.Trim();
        if (sanitizedValue.Length > MaxLength)
        {
            throw new ArgumentException($"Invalid municipality: {value}", nameof(value));
        }

        return new Municipality(sanitizedValue.Trim());
    }
}

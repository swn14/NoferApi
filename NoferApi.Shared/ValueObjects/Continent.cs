namespace NoferApi.Shared.ValueObjects;

public record Continent
{
    public string Code { get; }

    private static readonly HashSet<string> AllowedValues = new()
    {
        "AF", "AN", "AS", "EU", "NA", "OC", "SA"
    };

    private Continent(string code)
    {
        Code = code;
    }

    public static Continent FromCode(string code)
    {
        if (!AllowedValues.Contains(code))
        {
            throw new ArgumentException($"Invalid continent code: {code}", nameof(code));
        }
        return new Continent(code);
    }

    public override string ToString() => Code;
}

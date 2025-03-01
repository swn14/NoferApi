namespace NoferApi.Shared.ValueObjects;

public record Region
{
    public string IsoCode { get; }

    private Region(string isoCode)
    {
        IsoCode = isoCode;
    }

    public static Region FromCode(string code)
    {
        if (string.IsNullOrWhiteSpace(code) || !code.Contains("-") || code.Length < 3)
        {
            throw new ArgumentException($"Invalid region code: {code}", nameof(code));
        }
        return new Region(code);
    }

    public override string ToString() => IsoCode;
}

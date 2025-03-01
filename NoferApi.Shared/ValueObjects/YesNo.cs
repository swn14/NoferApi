namespace NoferApi.Shared.ValueObjects;

public record YesNo
{
    public string StringValue { get; }
    public bool BooleanValue { get; }

    private YesNo(string stringValue, bool booleanValue)
    {
        StringValue = stringValue;
        BooleanValue = booleanValue;
    }

    public static YesNo FromBoolean(bool value)
    {
        return new YesNo(value ? "yes" : "no", value);
    }

    public static YesNo FromString(string value)
    {
        return value.ToLower() switch
        {
            "yes" => new YesNo("yes", true),
            "no" => new YesNo("no", false),
            _ => throw new ArgumentException("Invalid YesNo value. Allowed values are 'yes' or 'no'.", nameof(value))
        };
    }

    public override string ToString() => StringValue;

    public static implicit operator bool(YesNo yesNo) => yesNo.BooleanValue;
    public static implicit operator string(YesNo yesNo) => yesNo.StringValue;
}

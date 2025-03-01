namespace NoferApi.Domain.Airports;

public class AirportType
{
    public static readonly AirportType Balloonport = new("balloonport");
    public static readonly AirportType ClosedAirport = new("closed_airport");
    public static readonly AirportType Heliport = new("heliport");
    public static readonly AirportType LargeAirport = new("large_airport");
    public static readonly AirportType MediumAirport = new("medium_airport");
    public static readonly AirportType SeaplaneBase = new("seaplane_base");
    public static readonly AirportType SmallAirport = new("small_airport");

    private static readonly HashSet<string> AllowedValues = new()
    {
        "balloonport",
        "closed_airport",
        "heliport",
        "large_airport",
        "medium_airport",
        "seaplane_base",
        "small_airport"
    };

    public string Value { get; }

    private AirportType(string value)
    {
        Value = value;
    }

    public static AirportType FromString(string value)
    {
        if (!AllowedValues.Contains(value))
        {
            throw new ArgumentException($"Invalid airport type: {value}", nameof(value));
        }

        return new AirportType(value);
    }
}

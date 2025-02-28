using NoferApi.Shared;

namespace NoferApi.Domain.Airports;

public class Airport : Entity
{
    public string Type { get; private set; }
    public string Name { get; private set; }
    public double Latitude { get; private set; }
    public double Longitude { get; private set; }
    public double ElevationFeet { get; private set; }
    public string Continent { get; private set; }
    public string IsoCountry { get; private set; }
    public string IsoRegion { get; private set; }
    public string Municipality { get; private set; }
    public string ScheduledService { get; private set; }
    public string GpsCode { get; private set; }
    public string IcaoCode { get; private set; }
    public string IatoCode { get; private set; }
    public string LocalCode { get; private set; }
    public string WebsiteLink { get; private set; }
    public string WikipediaLink { get; private set; }
    public HashSet<string> Keywords { get; private set; } = new HashSet<string>();

    private Airport(Action<Airport> setterAction)
    {
        setterAction(this);
    }

    public static Airport Create(Action<Airport> setterAction) => new(setterAction);
}
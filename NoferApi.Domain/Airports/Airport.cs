using NoferApi.Domain.Airports.ValueObjects;
using NoferApi.Shared;
using NoferApi.Shared.ValueObjects;

namespace NoferApi.Domain.Airports;

public class Airport : Entity
{
    public int Id { get; set; }
    public AirportType Type { get; set; }
    public AirportName Name { get; set; }
    public Latitude Latitude { get; set; }
    public Longitude Longitude { get; set; }
    public Elevation ElevationFeet { get; set; }
    public Continent Continent { get; set; }
    public Country IsoCountry { get; set; }
    public Region IsoRegion { get; set; }
    public Municipality Municipality { get; set; }
    public YesNo ScheduledService { get; set; }
    public AirportGpsCode GpsCode { get; set; }
    public AirportIcaoCode IcaoCode { get; set; }
    public AirportIataCode IataCode { get; set; }
    public AirportLocalCode LocalCode { get; set; }
    public Link WebsiteLink { get; set; }
    public Link WikipediaLink { get; set; }
    public List<string> Keywords { get; set; } = [];

}

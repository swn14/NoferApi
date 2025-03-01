using NoferApi.Application.Abstractions.Messaging;

namespace NoferApi.Application.Airports.CreateAirport;

public class CreateAirportCommand : ICommand<int>
{
    public string Type { get; set; }
    public string Name { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public double ElevationFeet { get; set; }
    public string Continent { get; set; }
    public string IsoCountry { get; set; }
    public string IsoRegion { get; set; }
    public string Municipality { get; set; }
    public string ScheduledService { get; set; }
    public string GpsCode { get; set; }
    public string IcaoCode { get; set; }
    public string IatoCode { get; set; }
    public string LocalCode { get; set; }
    public string WebsiteLink { get; set; }
    public string WikipediaLink { get; set; }
    public List<string> Keywords { get; set; } = [];
}

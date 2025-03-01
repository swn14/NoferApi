using MediatR;
using NoferApi.Api.Infrastructure;
using NoferApi.Application.Airports.CreateAirport;
using NoferApi.Shared;

namespace NoferApi.Api.Endpoints.Airports;

internal sealed class Create : IEndpoint
{
    private sealed class Request
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
        public string IataCode { get; set; }
        public string LocalCode { get; set; }
        public string WebsiteLink { get; set; }
        public string WikipediaLink { get; set; }
        public List<string> Keywords { get; set; } = [];
    }

    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("airports", async (Request request, ISender sender, CancellationToken cancellationToken) =>
            {
                var command = new CreateAirportCommand
                {
                    Name = request.Name,
                    Continent = request.Continent,
                    Type = request.Type,
                    Keywords = request.Keywords,
                    Latitude = request.Latitude,
                    Longitude = request.Longitude,
                    Municipality = request.Municipality,
                    IatoCode = request.IataCode,
                    IcaoCode = request.IcaoCode,
                    ElevationFeet = request.ElevationFeet,
                    GpsCode = request.GpsCode,
                    IsoCountry = request.IsoCountry,
                    IsoRegion = request.IsoRegion,
                    LocalCode = request.LocalCode,
                    ScheduledService = request.ScheduledService,
                    WikipediaLink = request.WikipediaLink,
                    WebsiteLink = request.WebsiteLink
                };

                Result<int> result = await sender.Send(command, cancellationToken);

                return result.Match(Results.Ok, CustomResults.Problem);
            })
            .WithTags(Tags.Airports);
    }
}

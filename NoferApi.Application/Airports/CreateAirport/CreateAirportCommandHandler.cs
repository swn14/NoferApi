using NoferApi.Application.Abstractions.Data;
using NoferApi.Application.Abstractions.Messaging;
using NoferApi.Domain.Airports;
using NoferApi.Domain.Airports.ValueObjects;
using NoferApi.Shared;
using NoferApi.Shared.ValueObjects;

namespace NoferApi.Application.Airports.CreateAirport;

public class CreateAirportCommandHandler(IAppDbContext context) : ICommandHandler<CreateAirportCommand, int>
{
    public async Task<Result<int>> Handle(CreateAirportCommand request, CancellationToken cancellationToken)
    {
        var airport = new Airport
        {
            Name = AirportName.FromString(request.Name),
            Continent = Continent.FromCode(request.Continent),
            Type = AirportType.FromString(request.Type),
            Keywords = request.Keywords,
            Latitude = Latitude.FromDouble(request.Latitude),
            Longitude = Longitude.FromDouble(request.Longitude),
            Municipality = Municipality.FromString(request.Municipality),
            IataCode = AirportIataCode.FromString(request.IatoCode),
            IcaoCode = AirportIcaoCode.FromString(request.IcaoCode),
            ElevationFeet = Elevation.FromDouble(request.ElevationFeet),
            GpsCode = AirportGpsCode.FromString(request.GpsCode),
            IsoCountry = Country.FromCode(request.IsoCountry),
            IsoRegion = Region.FromCode(request.IsoRegion),
            LocalCode = AirportLocalCode.FromString(request.LocalCode),
            ScheduledService = YesNo.FromString(request.ScheduledService),
            WikipediaLink = Link.FromString(request.WikipediaLink),
            WebsiteLink = Link.FromString(request.WebsiteLink)
        };
        
        airport.Raise(new AirportCreatedDomainEvent(airport.Id));
        
        context.Airports.Add(airport);

        await context.SaveChangesAsync(cancellationToken);

        return airport.Id;
    }
}

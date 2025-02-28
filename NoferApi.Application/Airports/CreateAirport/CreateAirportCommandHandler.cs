using NoferApi.Application.Abstractions.Data;
using NoferApi.Application.Abstractions.Messaging;
using NoferApi.Domain.Airports;
using NoferApi.Shared;

namespace NoferApi.Application.Airports.CreateAirport;

public class CreateAirportCommandHandler(IAppDbContext context) : ICommandHandler<CreateAirportCommand, int>
{
    public async Task<Result<int>> Handle(CreateAirportCommand request, CancellationToken cancellationToken)
    {
        var airport = new Airport
        {
            Name = request.Name,
            Continent = request.Continent,
            Type = request.Type,
            Keywords = request.Keywords,
            Latitude = request.Latitude,
            Longitude = request.Longitude,
            Municipality = request.Municipality,
            IatoCode = request.IatoCode,
            IcaoCode = request.IcaoCode,
            ElevationFeet = request.ElevationFeet,
            GpsCode = request.GpsCode,
            IsoCountry = request.IsoCountry,
            IsoRegion = request.IsoRegion,
            LocalCode = request.LocalCode,
            ScheduledService = request.ScheduledService,
            WikipediaLink = request.WikipediaLink,
            WebsiteLink = request.WebsiteLink,
        };
        
        airport.Raise(new AirportCreatedDomainEvent(airport.Id));
        
        context.Airports.Add(airport);

        await context.SaveChangesAsync(cancellationToken);

        return airport.Id;
    }
}
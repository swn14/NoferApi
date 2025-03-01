using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoferApi.Domain.Airports;
using NoferApi.Domain.Airports.ValueObjects;
using NoferApi.Shared.ValueObjects;

namespace NoferApi.Infrastructure.Airports;

public class AirportConfiguration : IEntityTypeConfiguration<Airport>
{
    public void Configure(EntityTypeBuilder<Airport> builder)
    {
        builder.HasKey(airport => airport.Id);
        builder
            .Property(airport => airport.Type)
            .HasConversion(valueType => valueType.Value, primitive => AirportType.FromString(primitive));
        builder
            .Property(airport => airport.Name)
            .HasConversion(valueType => valueType.Value, primitive => AirportName.FromString(primitive));
        builder
            .Property(airport => airport.Latitude)
            .HasConversion(valueType => valueType.Value, primitive => Latitude.FromDouble(primitive));
        builder
            .Property(airport => airport.Longitude)
            .HasConversion(valueType => valueType.Value, primitive => Longitude.FromDouble(primitive));
        builder
            .Property(airport => airport.ElevationFeet)
            .HasConversion(valueType => valueType.Value, primitive => Elevation.FromDouble(primitive));
        builder
            .Property(airport => airport.Continent)
            .HasConversion(valueType => valueType.Code, primitive => Continent.FromCode(primitive));
        builder
            .Property(airport => airport.IsoCountry)
            .HasConversion(valueType => valueType.IsoCode, primitive => Country.FromCode(primitive));
        builder
            .Property(airport => airport.IsoRegion)
            .HasConversion(valueType => valueType.IsoCode, primitive => Region.FromCode(primitive));
        builder
            .Property(airport => airport.Municipality)
            .HasConversion(valueType => valueType.Value, primitive => Municipality.FromString(primitive));
        builder
            .Property(airport => airport.ScheduledService)
            .HasConversion(valueType => valueType.StringValue, primitive => YesNo.FromString(primitive));
        builder
            .Property(airport => airport.GpsCode)
            .HasConversion(valueType => valueType.Value, primitive => AirportGpsCode.FromString(primitive));
        builder
            .Property(airport => airport.IcaoCode)
            .HasConversion(valueType => valueType.Value, primitive => AirportIcaoCode.FromString(primitive));
        builder
            .Property(airport => airport.IataCode)
            .HasConversion(valueType => valueType.Value, primitive => AirportIataCode.FromString(primitive));
        builder
            .Property(airport => airport.LocalCode)
            .HasConversion(valueType => valueType.Value, primitive => AirportLocalCode.FromString(primitive));
        builder
            .Property(airport => airport.WikipediaLink)
            .HasConversion(valueType => valueType.Value, primitive => Link.FromString(primitive));
        builder
            .Property(airport => airport.WebsiteLink)
            .HasConversion(valueType => valueType.Value, primitive => Link.FromString(primitive));
    }
}

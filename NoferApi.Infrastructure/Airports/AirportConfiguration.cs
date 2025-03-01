using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NoferApi.Domain.Airports;

namespace NoferApi.Infrastructure.Airports;

public class AirportConfiguration : IEntityTypeConfiguration<Airport>
{
    public void Configure(EntityTypeBuilder<Airport> builder)
    {
        builder.HasKey(airport => airport.Id);
        builder
            .Property(airport => airport.Type)
            .HasConversion(x => x.Value, x => AirportType.FromString(x));
    }
}

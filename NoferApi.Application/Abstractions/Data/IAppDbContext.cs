using Microsoft.EntityFrameworkCore;
using NoferApi.Domain.Airports;

namespace NoferApi.Application.Abstractions.Data;

public interface IAppDbContext
{
    DbSet<Airport> Airports { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
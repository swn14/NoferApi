using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NoferApi.Application.Abstractions.Data;
using NoferApi.Domain.Airports;
using NoferApi.Shared;

namespace NoferApi.Infrastructure.Database;

public sealed class AppDbContext(DbContextOptions<AppDbContext> options, IPublisher publisher) : DbContext(options), IAppDbContext
{
    
    public DbSet<Airport> Airports { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        modelBuilder.HasDefaultSchema(Schemas.Default);
        
        modelBuilder.Entity<Airport>().ToTable("Airport");
    }
    
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        // When should you publish domain events?
        //
        // 1. BEFORE calling SaveChangesAsync
        //     - domain events are part of the same transaction
        //     - immediate consistency
        // 2. AFTER calling SaveChangesAsync
        //     - domain events are a separate transaction
        //     - eventual consistency
        //     - handlers can fail
        UpdateTimestamps();
        int result = await base.SaveChangesAsync(cancellationToken);

        await PublishDomainEventsAsync();

        return result;
    }
    
    private void UpdateTimestamps()
    {
        IEnumerable<EntityEntry> entries = ChangeTracker.Entries()
            .Where(
                e => e.Entity is Entity &&
                     (e.State == EntityState.Added || e.State == EntityState.Modified)
            );

        foreach (EntityEntry entityEntry in entries)
        {
            ((Entity)entityEntry.Entity).UpdatedAt = DateTime.UtcNow;
            if (entityEntry.State == EntityState.Added)
            {
                ((Entity)entityEntry.Entity).CreatedAt = DateTime.UtcNow;
            }
        }
    }

    
    private async Task PublishDomainEventsAsync()
    {
        var domainEvents = ChangeTracker
            .Entries<Entity>()
            .Select(entry => entry.Entity)
            .SelectMany(entity =>
            {
                List<IDomainEvent> domainEvents = entity.DomainEvents;

                entity.ClearDomainEvents();

                return domainEvents;
            })
            .ToList();

        foreach (IDomainEvent domainEvent in domainEvents)
        {
            await publisher.Publish(domainEvent);
        }
    }
}

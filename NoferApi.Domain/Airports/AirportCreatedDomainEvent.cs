using NoferApi.Shared;

namespace NoferApi.Domain.Airports;

public sealed record AirportCreatedDomainEvent(int AirportId) : IDomainEvent;

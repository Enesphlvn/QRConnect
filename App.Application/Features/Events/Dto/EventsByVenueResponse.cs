using App.Application.Features.Venues.Dto;

namespace App.Application.Features.Events.Dto;

public record EventsByVenueResponse(int Id, string Name, DateTimeOffset Date, decimal Price, string? Description, VenueResponse Venue, int VenueId);
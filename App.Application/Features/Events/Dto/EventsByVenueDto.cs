using App.Application.Features.Venues.Dto;

namespace App.Application.Features.Events.Dto;

public record EventsByVenueDto(int Id, string Name, DateTimeOffset Date, decimal Price, string? Description, VenueDto Venue, int VenueId);
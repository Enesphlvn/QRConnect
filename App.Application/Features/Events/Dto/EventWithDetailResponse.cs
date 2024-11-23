using App.Application.Features.EventTypes.Dto;
using App.Application.Features.Venues.Dto;

namespace App.Application.Features.Events.Dto;

public record EventWithDetailResponse(int Id, string Name, DateTimeOffset Date, decimal Price, string? Description, EventTypeResponse EventType, VenueWithDetailResponse Venue);
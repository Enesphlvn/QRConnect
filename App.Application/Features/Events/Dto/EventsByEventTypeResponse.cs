using App.Application.Features.EventTypes.Dto;

namespace App.Application.Features.Events.Dto;

public record EventsByEventTypeResponse(int Id, string Name, DateTimeOffset Date, decimal Price, string? Description, EventTypeResponse EventType, int VenueId);
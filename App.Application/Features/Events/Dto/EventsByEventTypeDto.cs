using App.Application.Features.EventTypes.Dto;

namespace App.Application.Features.Events.Dto;

public record EventsByEventTypeDto(int Id, string Name, DateTimeOffset Date, decimal Price, string? Description, EventTypeDto EventType, int VenueId);
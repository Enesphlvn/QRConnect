using App.Application.Features.Events.Dto;

namespace App.Application.Features.EventTypes.Dto;

public record EventTypeWithEventsResponse(int Id, string Name, List<EventResponse> Events);
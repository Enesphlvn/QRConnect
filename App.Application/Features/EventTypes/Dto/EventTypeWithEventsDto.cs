using App.Application.Features.Events.Dto;

namespace App.Application.Features.EventTypes.Dto;

public record EventTypeWithEventsDto(int Id, string Name, List<EventDto> Events);
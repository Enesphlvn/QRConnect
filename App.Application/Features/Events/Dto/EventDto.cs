namespace App.Application.Features.Events.Dto;

public record EventDto(int Id, string Name, DateTime Date, decimal Price, string? Description, int EventTypeId, int VenueId);
namespace App.Application.Features.Events.Dto;

public record EventDto(int Id, string Name, DateTimeOffset Date, decimal Price, string? Description, int EventTypeId, int VenueId);
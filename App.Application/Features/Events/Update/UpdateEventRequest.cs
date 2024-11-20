namespace App.Application.Features.Events.Update;

public record UpdateEventRequest(string Name, DateTimeOffset Date, decimal Price, string? Description, int EventTypeId, int VenueId);
namespace App.Application.Features.Events.Update;

public record UpdateEventRequest(string Name, DateTime Date, decimal Price, string? Description);
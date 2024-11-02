namespace App.Application.Features.Events.Update;

public record UpdateEventRequest(string Name, DateTime Date, string Address, decimal Price, string Description);
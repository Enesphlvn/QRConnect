namespace App.Application.Features.Events.Dto;

public record EventDto(int Id, string Name, DateTime Date, string Address, decimal Price, string? Description);
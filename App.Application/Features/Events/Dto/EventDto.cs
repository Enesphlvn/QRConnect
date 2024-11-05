namespace App.Application.Features.Events.Dto;

public record EventDto(int Id, string Name, DateTime Date, string City, string District, decimal Price, string? Description);
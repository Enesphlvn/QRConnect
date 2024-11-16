namespace App.Application.Features.Venues.Dto;

public record VenueDto(int Id, string Name, int CityId, int DistrictId, int Capacity);
namespace App.Application.Features.Venues.Dto;

public record VenueResponse(int Id, string Name, int CityId, int DistrictId, int Capacity);
using App.Application.Features.Cities.Dto;

namespace App.Application.Features.Venues.Dto;

public record VenueByDistrictResponse(int Id, string Name, CityResponse City, int DistrictId, int Capacity);
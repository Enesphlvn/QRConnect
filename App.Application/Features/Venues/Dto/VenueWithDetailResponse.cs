using App.Application.Features.Cities.Dto;
using App.Application.Features.Districts.Dto;

namespace App.Application.Features.Venues.Dto;

public record VenueWithDetailResponse(int Id, string Name, CityResponse City, DistrictResponse District, int Capacity);
using App.Application.Features.Cities.Dto;
using App.Application.Features.Districts.Dto;

namespace App.Application.Features.Venues.Dto;

public record VenueWithDetailDto(int Id, string Name, CityDto City, DistrictDto District, int Capacity);
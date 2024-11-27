using App.Application.Features.Districts.Dto;

namespace App.Application.Features.Venues.Dto;

public record VenueByCityResponse(int Id, string Name, int CityId, DistrictResponse District, int Capacity);
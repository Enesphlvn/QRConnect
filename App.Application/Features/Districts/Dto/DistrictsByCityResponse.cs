using App.Application.Features.Cities.Dto;

namespace App.Application.Features.Districts.Dto;

public record DistrictsByCityResponse(int Id, string Name, CityResponse City);
using App.Application.Features.Districts.Dto;

namespace App.Application.Features.Cities.Dto;

public record CityWithDistrictsResponse(int Id, string Name, List<DistrictResponse> Districts);
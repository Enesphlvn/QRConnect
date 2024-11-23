using App.Application.Features.Districts.Dto;

namespace App.Application.Features.Cities.Dto;

public record CityWithDistrictsAndVenuesResponse(int Id, string Name, List<DistrictWithVenuesResponse> Districts);
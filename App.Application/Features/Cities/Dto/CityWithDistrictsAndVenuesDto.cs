using App.Application.Features.Districts.Dto;

namespace App.Application.Features.Cities.Dto;

public record CityWithDistrictsAndVenuesDto(int Id, string Name, List<DistrictWithVenuesDto> Districts);
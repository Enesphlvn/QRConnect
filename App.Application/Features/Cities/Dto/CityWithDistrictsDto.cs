using App.Application.Features.Districts.Dto;

namespace App.Application.Features.Cities.Dto;

public record CityWithDistrictsDto(int Id, string Name, List<DistrictDto> Districts);
using App.Application.Features.Venues.Dto;

namespace App.Application.Features.Districts.Dto;

public record DistrictWithVenuesDto(int Id, string Name, int CityId, List<VenueDto> Venues);
using App.Application.Features.Venues.Dto;

namespace App.Application.Features.Districts.Dto;

public record DistrictWithVenuesResponse(int Id, string Name, int CityId, List<VenueResponse> Venues);
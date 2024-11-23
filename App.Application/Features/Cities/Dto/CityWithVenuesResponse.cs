using App.Application.Features.Venues.Dto;

namespace App.Application.Features.Cities.Dto;

public record CityWithVenuesResponse(int Id, string Name, List<VenueResponse> Venues);
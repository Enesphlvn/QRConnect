using App.Application.Features.Venues.Dto;

namespace App.Application.Features.Cities.Dto;

public record CityWithVenuesDto(int Id, string Name, List<VenueDto> Venues);
using App.Application.Features.Events.Dto;

namespace App.Application.Features.Venues.Dto;

public record VenueWithEventsResponse(int Id, string Name, int CityId, int DistrictId, int Capacity, List<EventResponse> Events);
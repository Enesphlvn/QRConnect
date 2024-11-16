namespace App.Application.Features.Venues.Update;

public record UpdateVenueRequest(string Name, int CityId, int DistrictId, int Capacity);
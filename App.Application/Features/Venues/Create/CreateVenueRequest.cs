namespace App.Application.Features.Venues.Create;

public record CreateVenueRequest(string Name, int CityId, int DistrictId, int Capacity);
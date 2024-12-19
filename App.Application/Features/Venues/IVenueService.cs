using App.Application.Features.Venues.Create;
using App.Application.Features.Venues.Dto;
using App.Application.Features.Venues.Update;

namespace App.Application.Features.Venues
{
    public interface IVenueService
    {
        Task<ServiceResult<List<VenueResponse>>> GetAllListAsync();
        Task<ServiceResult<List<VenueResponse>>> GetPagedAllListAsync(int pageNumber, int pageSize);
        Task<ServiceResult<List<VenueByCityResponse>>> GetVenueByCityAsync(int cityId);
        Task<ServiceResult<List<VenueByDistrictResponse>>> GetVenueByDistrictAsync(int districtId);
        Task<ServiceResult<VenueResponse>> GetByIdAsync(int id);
        Task<ServiceResult<VenueWithEventsResponse>> GetVenueWithEventsAsync(int venueId);
        Task<ServiceResult<List<VenueWithEventsResponse>>> GetVenuesWithEventsAsync();
        Task<ServiceResult<int>> CreateAsync(CreateVenueRequest request);
        Task<ServiceResult> UpdateAsync(int id, UpdateVenueRequest request);
        Task<ServiceResult> DeleteAsync(int id);
        Task<ServiceResult> PassiveAsync(int id);
    }
}

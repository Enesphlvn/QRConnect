using App.Application.Features.Venues.Create;
using App.Application.Features.Venues.Dto;
using App.Application.Features.Venues.Update;

namespace App.Application.Features.Venues
{
    public interface IVenueService
    {
        Task<ServiceResult<List<VenueDto>>> GetAllListAsync();
        Task<ServiceResult<List<VenueDto>>> GetPagedAllListAsync(int pageNumber, int pageSize);
        Task<ServiceResult<VenueDto>> GetByIdAsync(int id);
        Task<ServiceResult<int>> CreateAsync(CreateVenueRequest request);
        Task<ServiceResult> UpdateAsync(int id, UpdateVenueRequest request);
        Task<ServiceResult> DeleteAsync(int id);
        Task<ServiceResult> PassiveAsync(int id);
    }
}

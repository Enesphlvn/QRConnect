using App.Application.Features.Districts.Create;
using App.Application.Features.Districts.Dto;
using App.Application.Features.Districts.Update;

namespace App.Application.Features.Districts
{
    public interface IDistrictService
    {
        Task<ServiceResult<List<DistrictResponse>>> GetAllListAsync();
        Task<ServiceResult<List<DistrictResponse>>> GetPagedAllListAsync(int pageNumber, int pageSize);
        Task<ServiceResult<DistrictWithVenuesResponse>> GetDistrictWithVenuesAsync(int id);
        Task<ServiceResult<List<DistrictWithVenuesResponse>>> GetDistrictWithVenuesAsync();
        Task<ServiceResult<List<DistrictsByCityResponse>>> GetDistrictsByCityAsync(int cityId);
        Task<ServiceResult<DistrictResponse>> GetByIdAsync(int id);
        Task<ServiceResult<int>> CreateAsync(CreateDistrictRequest request);
        Task<ServiceResult> UpdateAsync(int id, UpdateDistrictRequest request);
        Task<ServiceResult> DeleteAsync(int id);
        Task<ServiceResult> PassiveAsync(int id);
    }
}

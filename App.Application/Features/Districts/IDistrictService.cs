using App.Application.Features.Districts.Create;
using App.Application.Features.Districts.Dto;
using App.Application.Features.Districts.Update;

namespace App.Application.Features.Districts
{
    public interface IDistrictService
    {
        Task<ServiceResult<List<DistrictDto>>> GetAllListAsync();
        Task<ServiceResult<List<DistrictDto>>> GetPagedAllListAsync(int pageNumber, int pageSize);
        Task<ServiceResult<DistrictDto>> GetByIdAsync(int id);
        Task<ServiceResult<int>> CreateAsync(CreateDistrictRequest request);
        Task<ServiceResult> UpdateAsync(int id, UpdateDistrictRequest request);
        Task<ServiceResult> DeleteAsync(int id);
        Task<ServiceResult> PassiveAsync(int id);
    }
}

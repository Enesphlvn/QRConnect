using App.Application.Features.Cities.Create;
using App.Application.Features.Cities.Dto;
using App.Application.Features.Cities.Update;

namespace App.Application.Features.Cities
{
    public interface ICityService
    {
        Task<ServiceResult<List<CityDto>>> GetAllListAsync();
        Task<ServiceResult<List<CityDto>>> GetPagedAllListAsync(int pageNumber, int pageSize);
        Task<ServiceResult<CityDto>> GetByIdAsync(int id);
        Task<ServiceResult<int>> CreateAsync(CreateCityRequest request);
        Task<ServiceResult> UpdateAsync(int id, UpdateCityRequest request);
        Task<ServiceResult> DeleteAsync(int id);
        Task<ServiceResult> PassiveAsync(int id);
    }
}

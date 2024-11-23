using App.Application.Features.Cities.Create;
using App.Application.Features.Cities.Dto;
using App.Application.Features.Cities.Update;

namespace App.Application.Features.Cities
{
    public interface ICityService
    {
        Task<ServiceResult<List<CityResponse>>> GetAllListAsync();
        Task<ServiceResult<List<CityResponse>>> GetPagedAllListAsync(int pageNumber, int pageSize);
        Task<ServiceResult<CityWithDistrictsResponse>> GetCityWithDistrictsAsync(int cityId);
        Task<ServiceResult<List<CityWithDistrictsResponse>>> GetCityWithDistrictsAsync();
        Task<ServiceResult<CityWithVenuesResponse>> GetCityWithVenuesAsync(int cityId);
        Task<ServiceResult<CityWithDistrictsAndVenuesResponse>> GetCityWithDistrictsAndVenuesAsync(int id);
        Task<ServiceResult<List<CityWithVenuesResponse>>> GetCityWithVenuesAsync();
        Task<ServiceResult<CityResponse>> GetByIdAsync(int id);
        Task<ServiceResult<int>> CreateAsync(CreateCityRequest request);
        Task<ServiceResult> UpdateAsync(int id, UpdateCityRequest request);
        Task<ServiceResult> DeleteAsync(int id);
        Task<ServiceResult> PassiveAsync(int id);
    }
}

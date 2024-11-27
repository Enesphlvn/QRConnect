using App.Domain.Entities;

namespace App.Application.Contracts.Persistence
{
    public interface IDistrictRepository : IGenericRepository<District, int>
    {
        Task<District?> GetDistrictVenuesAsync(int id);
        Task<List<District>> GetDistrictVenuesAsync();
        Task<List<District>> GetDistrictsByCityAsync(int cityId);
    }
}

using App.Domain.Entities;

namespace App.Application.Contracts.Persistence
{
    public interface ICityRepository : IGenericRepository<City, int>
    {
        Task<City> GetCityWithDistrictsAsync(int id);
        Task<List<City>> GetCityWithDistrictsAsync();
    }
}

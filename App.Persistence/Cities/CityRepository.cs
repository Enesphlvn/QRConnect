using App.Application.Contracts.Persistence;
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Persistence.Cities
{
    public class CityRepository(AppDbContext context) : GenericRepository<City, int>(context), ICityRepository
    {
        public Task<City> GetCityWithDistrictsAsync(int id)
        {
            return context.Cities.Include(x => x.Districts).FirstOrDefaultAsync(x => x.Id == id)!;
        }

        public Task<List<City>> GetCityWithDistrictsAsync()
        {
            return context.Cities.Include(x => x.Districts).ToListAsync();
        }

        public Task<City?> GetCityWithVenuesAsync(int id)
        {
            return context.Cities.Include(x => x.Venues).FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<List<City>> GetCityWithVenuesAsync()
        {
            return context.Cities.Include(x => x.Venues).ToListAsync();
        }
    }
}

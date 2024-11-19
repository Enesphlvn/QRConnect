using App.Application.Contracts.Persistence;
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Persistence.Cities
{
    public class CityRepository(AppDbContext context) : GenericRepository<City, int>(context), ICityRepository
    {
        public async Task<City> GetCityWithDistrictsAsync(int id)
        {
            return (await Context.Cities.Include(x => x.Districts).FirstOrDefaultAsync(x => x.Id == id))!;
        }

        public async Task<List<City>> GetCityWithDistrictsAsync()
        {
            return await Context.Cities.Include(x => x.Districts).ToListAsync();
        }

        public async Task<City?> GetCityWithVenuesAsync(int id)
        {
            return await Context.Cities.Include(x => x.Venues).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<City>> GetCityWithVenuesAsync()
        {
            return await Context.Cities.Include(x => x.Venues).ToListAsync();
        }

        public async Task<City?> GetCityWithDistrictsAndVenuesAsync(int id)
        {
            return await Context.Cities.Include(x => x.Districts).ThenInclude(d => d.Venues).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}

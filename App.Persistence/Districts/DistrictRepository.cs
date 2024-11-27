using App.Application.Contracts.Persistence;
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Persistence.Districts
{
    public class DistrictRepository(AppDbContext context) : GenericRepository<District, int>(context), IDistrictRepository
    {
        public async Task<District?> GetDistrictVenuesAsync(int id)
        {
            return await Context.Districts.Include(x => x.Venues).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<District>> GetDistrictVenuesAsync()
        {
            return await Context.Districts.Include(x => x.Venues).ToListAsync();
        }

        public async Task<List<District>> GetDistrictsByCityAsync(int cityId)
        {
            return await Context.Districts.Include(x => x.City).Where(x => x.CityId == cityId).ToListAsync();
        }
    }
}

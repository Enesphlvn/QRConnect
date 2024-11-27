using App.Application.Contracts.Persistence;
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Persistence.Venues
{
    public class VenueRepository(AppDbContext context) : GenericRepository<Venue, int>(context), IVenueRepository
    {
        public async Task<List<Venue>> GetVenueByCityAsync(int cityId)
        {
            return await Context.Venues.Include(x => x.District).Where(x => x.CityId == cityId).ToListAsync();
        }

        public async Task<List<Venue>> GetVenueByDistrictAsync(int districtId)
        {
            return await Context.Venues.Include(x => x.City).Where(x => x.DistrictId == districtId).ToListAsync();
        }
    }
}

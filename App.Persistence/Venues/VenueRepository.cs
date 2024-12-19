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

        public async Task<Venue?> GetVenueWithEventsAsync(int venueId)
        {
            return await Context.Venues.Include(x => x.Events).FirstOrDefaultAsync(x => x.Id == venueId);
        }

        public async Task<List<Venue>> GetVenuesWithEventsAsync()
        {
            return await Context.Venues.Include(x => x.Events).ToListAsync();
        }

        public async Task<bool> DecreaseCapacityAsync(int venueId)
        {
            var venue = await Context.Venues.FirstOrDefaultAsync(v => v.Id == venueId);

            if (venue == null || venue.Capacity <= 0)
            {
                return false;
            }

            venue.Capacity--;

            Context.Venues.Update(venue);

            await Context.SaveChangesAsync();

            return true;
        }
    }
}

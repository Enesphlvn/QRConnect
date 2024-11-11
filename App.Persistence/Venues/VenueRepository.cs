using App.Application.Contracts.Persistence;
using App.Domain.Entities;

namespace App.Persistence.Venues
{
    public class VenueRepository(AppDbContext context) : GenericRepository<Venue, int>(context), IVenueRepository
    {
    }
}

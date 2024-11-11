using App.Domain.Entities;

namespace App.Application.Contracts.Persistence
{
    public interface IVenueRepository : IGenericRepository<Venue, int>
    {
    }
}

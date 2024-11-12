using App.Application.Contracts.Persistence;
using App.Domain.Entities;

namespace App.Persistence.Cities
{
    public class CityRepository(AppDbContext context) : GenericRepository<City, int>(context), ICityRepository
    {
    }
}

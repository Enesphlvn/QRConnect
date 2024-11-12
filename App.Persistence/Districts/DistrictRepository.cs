using App.Application.Contracts.Persistence;
using App.Domain.Entities;

namespace App.Persistence.Districts
{
    public class DistrictRepository(AppDbContext context) : GenericRepository<District, int>(context), IDistrictRepository
    {
    }
}

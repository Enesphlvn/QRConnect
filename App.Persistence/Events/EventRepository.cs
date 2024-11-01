using App.Application.Contracts.Persistence;
using App.Domain.Entities;

namespace App.Persistence.Events
{
    public class EventRepository(AppDbContext context) : GenericRepository<Event, int>(context), IEventRepository
    {
    }
}

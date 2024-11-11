using App.Application.Contracts.Persistence;
using App.Domain.Entities;

namespace App.Persistence.EventTypes
{
    public class EventTypeRepository(AppDbContext context) : GenericRepository<EventType, int>(context), IEventTypeRepository
    {
    }
}

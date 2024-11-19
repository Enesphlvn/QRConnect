using App.Application.Contracts.Persistence;
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Persistence.EventTypes
{
    public class EventTypeRepository(AppDbContext context) : GenericRepository<EventType, int>(context), IEventTypeRepository
    {
        public async Task<EventType?> GetEventTypeWithEventsAsync(int id)
        {
            return await Context.EventTypes.Include(x => x.Events).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<EventType>> GetEventTypeWithEventsAsync()
        {
            return await Context.EventTypes.Include(x => x.Events).ToListAsync();
        }
    }
}

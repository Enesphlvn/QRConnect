using App.Application.Contracts.Persistence;
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Persistence.Events
{
    public class EventRepository(AppDbContext context) : GenericRepository<Event, int>(context), IEventRepository
    {
        public async Task<List<Event>> GetEventsByEventType(int eventTypeId)
        {
            return await Context.Events.Include(x => x.EventType).Where(x => x.EventTypeId == eventTypeId).ToListAsync();
        }

        public async Task<List<Event>> GetEventsByVenue(int venueId)
        {
            return await Context.Events.Include(x => x.Venue).Where(x => x.VenueId == venueId).ToListAsync();
        }

        public async Task<List<Event>> GetEventsWithHighestSales(int numberOffEvents)
        {
            return await Context.Events.Include(x => x.Tickets).OrderByDescending(x => (x.Tickets!).Count())
                .Take(numberOffEvents).ToListAsync();
        }
    }
}

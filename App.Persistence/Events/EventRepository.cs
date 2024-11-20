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

        public async Task<List<Event>> GetEventsByDateRange(DateTimeOffset startDate, DateTimeOffset endDate)
        {
            return await Context.Events.Where(x => x.Date >= startDate && x.Date <= endDate).ToListAsync();
        }

        public async Task<List<Event>> GetEventsByPriceRange(decimal minPrice, decimal maxPrice)
        {
            return await Context.Events.Where(x => x.Price >= minPrice && x.Price <= maxPrice).ToListAsync();
        }

        public async Task<List<Event>> GetEventsByUserTickets(int userId)
        {
            return await Context.Events.Include(x => x.Tickets).Where(x => x.Tickets!.Any(x => x.UserId == userId)).ToListAsync();
        }
    }
}

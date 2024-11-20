using App.Domain.Entities;

namespace App.Application.Contracts.Persistence
{
    public interface IEventRepository : IGenericRepository<Event, int>
    {
        Task<List<Event>> GetEventsByEventType(int eventTypeId);
        Task<List<Event>> GetEventsByVenue(int venueId);
        Task<List<Event>> GetEventsWithHighestSales(int numberOffEvents);
        Task<List<Event>> GetEventsByDateRange(DateTimeOffset startDate, DateTimeOffset endDate);
        Task<List<Event>> GetEventsByPriceRange(decimal minPrice, decimal maxPrice);
        Task<List<Event>> GetEventsByUserTickets(int userId);
    }
}

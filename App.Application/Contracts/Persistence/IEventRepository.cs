using App.Domain.Entities;

namespace App.Application.Contracts.Persistence
{
    public interface IEventRepository : IGenericRepository<Event, int>
    {
        Task<Event?> GetEventWithDetailAsync(int eventId);
        Task<List<Event>> GetEventsByEventTypeAsync(int eventTypeId);
        Task<List<Event>> GetEventsByVenueAsync(int venueId);
        Task<List<Event>> GetEventsWithHighestSalesAsync(int numberOffEvents);
        Task<List<Event>> GetEventsByDateRangeAsync(DateTimeOffset startDate, DateTimeOffset endDate);
        Task<List<Event>> GetEventsByPriceRangeAsync(decimal minPrice, decimal maxPrice);
        Task<List<Event>> GetEventsByUserTicketsAsync(int userId);
    }
}

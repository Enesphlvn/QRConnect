using App.Domain.Entities;

namespace App.Application.Contracts.Persistence
{
    public interface ITicketRepository : IGenericRepository<Ticket, int>
    {
        Task<List<Ticket>> GetTicketsByEventAsync(int eventId);
        Task<List<Ticket>> GetTicketsByUserAsync(int userId);
        Task<List<Ticket>> GetTicketsWithDetailAsync();
        Task<bool> HasUserTicketForEventAsync(int userId, int eventId);
        Task<int> GetTicketCountByEventAsync(int id);
        Task<List<Ticket>> GetTicketsByDateRangeAsync(DateTimeOffset startDate, DateTimeOffset endDate);
    }
}

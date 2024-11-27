using App.Domain.Entities;

namespace App.Application.Contracts.Persistence
{
    public interface ITicketRepository : IGenericRepository<Ticket, int>
    {
        Task<List<Ticket>> GetTicketsByEventAsync(int eventId);
        Task<List<Ticket>> GetTicketsByUserAsync(int userId);
    }
}

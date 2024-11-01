using App.Domain.Entities;

namespace App.Application.Contracts.Persistence
{
    public interface ITicketRepository : IGenericRepository<Ticket, int>
    {
    }
}

using App.Application.Contracts.Persistence;
using App.Domain.Entities;

namespace App.Persistence.Tickets
{
    public class TicketRepository(AppDbContext context) : GenericRepository<Ticket, int>(context), ITicketRepository
    {
    }
}

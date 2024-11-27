using App.Application.Contracts.Persistence;
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Persistence.Tickets
{
    public class TicketRepository(AppDbContext context) : GenericRepository<Ticket, int>(context), ITicketRepository
    {
        public async Task<List<Ticket>> GetTicketsByEventAsync(int eventId)
        {
            return await Context.Tickets.Include(x => x.User).Where(x => x.EventId == eventId).ToListAsync();
        }

        public async Task<List<Ticket>> GetTicketsByUserAsync(int userId)
        {
            return await Context.Tickets.Include(x => x.Event).Where(x => x.UserId == userId).ToListAsync();
        }
    }
}

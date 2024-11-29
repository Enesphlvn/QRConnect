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

        public async Task<List<Ticket>> GetTicketsWithDetailAsync()
        {
            return await Context.Tickets.Include(x => x.Event).Include(x => x.User).ToListAsync();
        }

        public async Task<bool> HasUserTicketForEventAsync(int userId, int eventId)
        {
            return await Context.Tickets.AnyAsync(x => x.UserId == userId && x.EventId == eventId);
        }

        // Bir Etkinlikteki Mevcut Bilet Sayısını Kontrol Etmek
        public async Task<int> GetTicketCountByEventAsync(int id)
        {
            return await Context.Tickets.CountAsync(x => x.EventId == id);
        }

        public async Task<List<Ticket>> GetTicketsByDateRangeAsync(DateTimeOffset startDate, DateTimeOffset endDate)
        {
            return await Context.Tickets.Include(x => x.Event).Include(x => x.User).Where(x => x.PurchaseDate >= startDate && x.PurchaseDate <= endDate).ToListAsync();
        }
    }
}

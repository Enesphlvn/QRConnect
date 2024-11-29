using App.Application.Contracts.Persistence;
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Persistence.Users
{
    public class UserRepository(AppDbContext context) : GenericRepository<User, int>(context), IUserRepository
    {
        public async Task<User?> GetUserWithTicketsAsync(int userId)
        {
            return await Context.Users.Include(x => x.Tickets).FirstOrDefaultAsync(x => x.Id == userId);
        }

        public async Task<List<User>> GetUsersWithTicketsAsync()
        {
            return await Context.Users.Include(x => x.Tickets).ToListAsync();
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return (await Context.Users.FirstOrDefaultAsync(x => x.Email.ToLower() == email.ToLower()))!;
        }
    }
}

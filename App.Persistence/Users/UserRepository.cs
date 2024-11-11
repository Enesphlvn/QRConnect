using App.Application.Contracts.Persistence;
using App.Domain.Entities;

namespace App.Persistence.Users
{
    public class UserRepository(AppDbContext context) : GenericRepository<User, int>(context), IUserRepository
    {
    }
}

using App.Domain.Entities;

namespace App.Application.Contracts.Persistence
{
    public interface IUserRepository : IGenericRepository<User, int>
    {
        Task<User?> GetUserWithTicketsAsync(int userId);
        Task<User> GetUserByEmailAsync(string email);
    }
}

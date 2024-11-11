using App.Domain.Entities;

namespace App.Application.Contracts.Persistence
{
    public interface IUserRepository : IGenericRepository<User, int>
    {
    }
}

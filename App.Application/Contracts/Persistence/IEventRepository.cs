using App.Domain.Entities;

namespace App.Application.Contracts.Persistence
{
    public interface IEventRepository : IGenericRepository<Event, int>
    {
    }
}

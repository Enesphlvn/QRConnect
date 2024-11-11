using App.Domain.Entities;

namespace App.Application.Contracts.Persistence
{
    public interface IEventTypeRepository : IGenericRepository<EventType, int>
    {
    }
}

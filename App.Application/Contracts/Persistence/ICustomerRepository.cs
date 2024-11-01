using App.Domain.Entities;

namespace App.Application.Contracts.Persistence
{
    public interface ICustomerRepository : IGenericRepository<Customer, int>
    {
    }
}

using App.Application.Contracts.Persistence;
using App.Domain.Entities;

namespace App.Persistence.Customers
{
    public class CustomerRepository(AppDbContext context) : GenericRepository<Customer, int>(context), ICustomerRepository
    {
    }
}

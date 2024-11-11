using App.Domain.Entities;

namespace App.Application.Contracts.Persistence
{
    public interface IUserOperationClaimRepository : IGenericRepository<UserOperationClaim, int>
    {
    }
}

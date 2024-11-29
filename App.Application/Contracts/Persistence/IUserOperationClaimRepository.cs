using App.Domain.Entities;

namespace App.Application.Contracts.Persistence
{
    public interface IUserOperationClaimRepository : IGenericRepository<UserOperationClaim, int>
    {
        Task<List<UserOperationClaim>> GetUserOperationClaimsWithDetailAsync();
        Task<List<UserOperationClaim>> GetUserOperationClaimByUserAsync(int userId);
        Task<List<UserOperationClaim>> GetUserOperationClaimByOperationClaimAsync(int operationClaimId);
    }
}

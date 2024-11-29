using App.Domain.Entities;

namespace App.Application.Contracts.Persistence
{
    public interface IOperationClaimRepository : IGenericRepository<OperationClaim, int>
    {
        Task<OperationClaim> GetOperationCalimWithUserOperationClaimsAsync(int id);
        Task<List<OperationClaim>> GetOperationCalimWithUserOperationClaimsAsync();
    }
}

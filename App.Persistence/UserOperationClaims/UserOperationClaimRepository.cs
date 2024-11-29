using App.Application.Contracts.Persistence;
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Persistence.UserOperationClaims
{
    public class UserOperationClaimRepository(AppDbContext context) : GenericRepository<UserOperationClaim, int>(context), IUserOperationClaimRepository
    {
        public async Task<List<UserOperationClaim>> GetUserOperationClaimsWithDetailAsync()
        {
            return await Context.UserOperationClaims.Include(x => x.User).Include(x => x.OperationClaim).ToListAsync();
        }

        public async Task<List<UserOperationClaim>> GetUserOperationClaimByUserAsync(int userId)
        {
            return await Context.UserOperationClaims.Include(x => x.User).Include(x => x.OperationClaim).Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task<List<UserOperationClaim>> GetUserOperationClaimByOperationClaimAsync(int operationClaimId)
        {
            return await Context.UserOperationClaims.Include(x => x.OperationClaim).Include(x => x.User).Where(x => x.OperationClaimId == operationClaimId).ToListAsync();
        }
    }
}

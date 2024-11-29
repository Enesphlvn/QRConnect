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
    }
}

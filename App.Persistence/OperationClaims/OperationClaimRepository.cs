using App.Application.Contracts.Persistence;
using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Persistence.OperationClaims
{
    public class OperationClaimRepository(AppDbContext context) : GenericRepository<OperationClaim, int>(context), IOperationClaimRepository
    {
        public async Task<OperationClaim> GetOperationCalimWithUserOperationClaimsAsync(int id)
        {
            return (await Context.OperationClaims.Include(x => x.UserOperationClaims).FirstOrDefaultAsync(x => x.Id == id))!;
        }

        public async Task<List<OperationClaim>> GetOperationCalimWithUserOperationClaimsAsync()
        {
            return await Context.OperationClaims.Include(x => x.UserOperationClaims).ToListAsync();
        }
    }
}

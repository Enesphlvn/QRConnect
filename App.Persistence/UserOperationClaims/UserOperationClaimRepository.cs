using App.Application.Contracts.Persistence;
using App.Domain.Entities;

namespace App.Persistence.UserOperationClaims
{
    public class UserOperationClaimRepository(AppDbContext context) : GenericRepository<UserOperationClaim, int>(context), IUserOperationClaimRepository
    {
    }
}

using App.Application.Contracts.Persistence;
using App.Domain.Entities;

namespace App.Persistence.OperationClaims
{
    public class OperationClaimRepository(AppDbContext context) : GenericRepository<OperationClaim, int>(context), IOperationClaimRepository
    {
    }
}

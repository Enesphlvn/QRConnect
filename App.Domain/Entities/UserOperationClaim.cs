using App.Domain.Entities.Common;

namespace App.Domain.Entities
{
    public class UserOperationClaim : BaseEntity<int>
    {
        public int UserId { get; set; }
        public User User { get; set; } = default!;
        public int OperationClaimId { get; set; }
        public OperationClaim OperationClaim { get; set; } = default!;
    }
}

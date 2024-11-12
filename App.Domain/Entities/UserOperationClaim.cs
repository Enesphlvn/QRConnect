using App.Domain.Entities.Common;

namespace App.Domain.Entities
{
    public class UserOperationClaim : BaseEntity<int>, IAuditEntity
    {
        public int UserId { get; set; }
        public User User { get; set; } = default!;
        public int OperationClaimId { get; set; }
        public OperationClaim OperationClaim { get; set; } = default!;
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}

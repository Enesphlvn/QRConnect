using App.Domain.Entities.Common;

namespace App.Domain.Entities
{
    public class OperationClaim : BaseEntity<int>, IAuditEntity
    {
        public string Name { get; set; } = default!;
        public List<UserOperationClaim> UserOperationClaims { get; set; } = [];
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}

using App.Domain.Entities.Common;

namespace App.Domain.Entities
{
    public class OperationClaim : BaseEntity<int>
    {
        public string Name { get; set; } = default!;
        public List<UserOperationClaim> UserOperationClaims { get; set; } = [];

    }
}

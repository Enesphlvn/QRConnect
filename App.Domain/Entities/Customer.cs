using App.Domain.Entities.Common;

namespace App.Domain.Entities
{
    public class Customer : BaseEntity<int>, IAuditEntity
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        public List<Ticket>? Tickets { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}

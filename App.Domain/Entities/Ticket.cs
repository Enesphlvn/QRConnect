using App.Domain.Entities.Common;

namespace App.Domain.Entities
{
    public class Ticket : BaseEntity<int>, IAuditEntity
    {
        public int EventId { get; set; }
        public int UserId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public Event Event { get; set; } = default!;
        public User User { get; set; } = default!;
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}

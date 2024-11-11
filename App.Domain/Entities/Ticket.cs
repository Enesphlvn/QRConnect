using App.Domain.Entities.Common;

namespace App.Domain.Entities
{ 
    public class Ticket : BaseEntity<int>, IAuditEntity
    {
        public int EventId { get; set; }
        public Event Event { get; set; } = default!;
        public int UserId { get; set; }
        public User User { get; set; } = default!;
        public DateTime PurchaseDate { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}

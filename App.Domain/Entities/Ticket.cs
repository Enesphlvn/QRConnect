using App.Domain.Entities.Common;

namespace App.Domain.Entities
{
    public class Ticket : BaseEntity<int>, IAuditEntity
    {
        public Guid EventId { get; set; }
        public Guid UserId { get; set; }
        public string QrCode { get; set; } = default!;
        public DateTime PurchaseDate { get; set; }
        public Event Event { get; set; } = default!;
        public Customer User { get; set; } = default!;
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}

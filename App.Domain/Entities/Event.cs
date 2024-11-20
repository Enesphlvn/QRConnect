using App.Domain.Entities.Common;

namespace App.Domain.Entities
{
    public class Event : BaseEntity<int>, IAuditEntity
    {
        public string Name { get; set; } = default!;
        public DateTimeOffset Date { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public int EventTypeId { get; set; }
        public EventType EventType { get; set; } = default!;
        public int VenueId { get; set; }
        public Venue Venue { get; set; } = default!;
        public List<Ticket>? Tickets { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Updated { get; set; }
    }
}

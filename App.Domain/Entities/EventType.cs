using App.Domain.Entities.Common;

namespace App.Domain.Entities
{
    public class EventType : BaseEntity<int>, IAuditEntity
    {
        public string Name { get; set; } = default!;
        public List<Event> Events { get; set; } = [];
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}

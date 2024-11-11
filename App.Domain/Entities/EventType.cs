using App.Domain.Entities.Common;

namespace App.Domain.Entities
{
    public class EventType : BaseEntity<int>
    {
        public string Name { get; set; } = default!;
        public List<Event> Events { get; set; } = [];
    }
}

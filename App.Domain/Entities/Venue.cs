using App.Domain.Entities.Common;

namespace App.Domain.Entities
{
    public class Venue : BaseEntity<int>
    {
        public string Name { get; set; } = default!;
        public string City { get; set; } = default!;
        public string District { get; set; } = default!;
        public int Capacity { get; set; }
        public List<Event> Events { get; set; } = [];
    }
}

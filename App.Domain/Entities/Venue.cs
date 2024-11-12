using App.Domain.Entities.Common;

namespace App.Domain.Entities
{
    public class Venue : BaseEntity<int>, IAuditEntity
    {
        public string Name { get; set; } = default!;
        public int CityId { get; set; }
        public City City { get; set; } = default!;
        public int DistrictId { get; set; } = default!;
        public District District { get; set; } = default!;
        public int? Capacity { get; set; }
        public List<Event> Events { get; set; } = [];
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}

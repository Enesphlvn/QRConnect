using App.Domain.Entities.Common;

namespace App.Domain.Entities
{
    public class City : BaseEntity<int>, IAuditEntity
    {
        public string Name { get; set; } = default!;
        public List<District> Districts { get; set; } = [];
        public List<Venue> Venues { get; set; } = [];
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Updated { get; set; }
    }
}

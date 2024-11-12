using App.Domain.Entities.Common;

namespace App.Domain.Entities
{
    public class City : BaseEntity<int>, IAuditEntity
    {
        public string Name { get; set; } = default!;
        public List<District> Districts { get; set; } = [];
        public List<Venue> Venues { get; set; } = [];
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}

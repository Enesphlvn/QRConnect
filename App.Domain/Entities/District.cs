using App.Domain.Entities.Common;

namespace App.Domain.Entities
{
    public class District : BaseEntity<int>, IAuditEntity
    {
        public string Name { get; set; } = default!;
        public int CityId { get; set; }
        public City City { get; set; } = default!;
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}

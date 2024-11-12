using App.Domain.Entities.Common;

namespace App.Domain.Entities
{
    public class District : BaseEntity<int>
    {
        public string Name { get; set; } = default!;
        public int CityId { get; set; }
        public City City { get; set; } = default!;
    }
}

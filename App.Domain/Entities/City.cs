using App.Domain.Entities.Common;

namespace App.Domain.Entities
{
    public class City : BaseEntity<int>
    {
        public string Name { get; set; } = default!;
        public List<District> Districts { get; set; } = [];
    }
}

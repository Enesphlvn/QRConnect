using App.Domain.Common;

namespace App.Domain.Entities
{
    public class Customer : BaseEntity<int>
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        public List<Ticket>? Tickets { get; set; }
    }
}

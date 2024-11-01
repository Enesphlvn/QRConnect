﻿using App.Domain.Entities.Common;

namespace App.Domain.Entities
{
    public class Event : BaseEntity<int>
    {
        public string Name { get; set; } = default!;
        public DateTime Date { get; set; }
        public string Address { get; set; } = default!;
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public List<Ticket>? Tickets { get; set; }
    }
}

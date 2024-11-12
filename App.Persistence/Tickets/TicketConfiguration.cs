using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Persistence.Tickets
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.PurchaseDate).IsRequired();

            builder.HasOne(x => x.Event).WithMany(e => e.Tickets).HasForeignKey(x => x.EventId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

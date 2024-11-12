using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Persistence.OperationClaims
{
    public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
    {
        public void Configure(EntityTypeBuilder<OperationClaim> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);

            builder.HasMany(x => x.UserOperationClaims).WithOne(uoc => uoc.OperationClaim)
                .HasForeignKey(uoc => uoc.OperationClaimId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

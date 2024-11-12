using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Persistence.UserOperationClaims
{
    public class UserOperationClaimConfiguration : IEntityTypeConfiguration<UserOperationClaim>
    {
        public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.User).WithMany(u => u.UserOperationClaims).HasForeignKey(x => x.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.OperationClaim).WithMany(oc => oc.UserOperationClaims).HasForeignKey(x => x.OperationClaimId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

using Mandegar.Models.Entities.Departments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mandegar.DataAccess.Configuration
{
    public class SessionApprovals_Config : IEntityTypeConfiguration<SessionApprovals>
    {
        public void Configure(EntityTypeBuilder<SessionApprovals> builder)
        {

            builder.HasOne(d => d.CreatedBy)
          .WithMany(p => p.SessionApprovalsCreatedBy)
          .HasForeignKey(d => d.CreatedById)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("FK_SessionApprovals_Users_CreatedBy");

            builder.HasOne(d => d.ModifiedBy)
                .WithMany(p => p.SessionApprovalsModifiedBy)
                .HasForeignKey(d => d.ModifiedById)
                .HasConstraintName("FK_SessionApprovals_Users_ModifiedBy");
        }
    }
}

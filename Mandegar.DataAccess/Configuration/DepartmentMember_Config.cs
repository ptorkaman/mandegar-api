using Mandegar.Models.Entities.Departments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mandegar.DataAccess.Configuration
{
    public class DepartmentMember_Config : IEntityTypeConfiguration<DepartmentMember>
    {
        public void Configure(EntityTypeBuilder<DepartmentMember> builder)
        {
            builder.HasOne(d => d.CreatedBy)
          .WithMany(p => p.DepartmentMemberCreatedBy)
          .HasForeignKey(d => d.CreatedById)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("FK_DepartmentMember_Users_CreatedBy");

            builder.HasOne(d => d.ModifiedBy)
                .WithMany(p => p.DepartmentMemberModifiedBy)
                .HasForeignKey(d => d.ModifiedById)
                .HasConstraintName("FK_DepartmentMember_Users_ModifiedBy");
        }
    }
}

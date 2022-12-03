using Mandegar.Models.Entities.Departments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mandegar.DataAccess.Configuration
{
    public class ProceedingsDepartment_Config : IEntityTypeConfiguration<ProceedingsDepartment>
    {
        public void Configure(EntityTypeBuilder<ProceedingsDepartment> builder)
        {
            builder.HasOne(d => d.CreatedBy)
          .WithMany(p => p.ProceedingsDepartmentCreatedBy)
          .HasForeignKey(d => d.CreatedById)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("FK_ProceedingsDepartment_Users_CreatedBy");

            builder.HasOne(d => d.ModifiedBy)
                .WithMany(p => p.ProceedingsDepartmentModifiedBy)
                .HasForeignKey(d => d.ModifiedById)
                .HasConstraintName("FK_ProceedingsDepartment_Users_ModifiedBy");
        }
    }
}

using Mandegar.Models.Entities.Departments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mandegar.DataAccess.Configuration
{
    public class DepartmentActivityType_Config : IEntityTypeConfiguration<DepartmentActivityType>
    {
        public void Configure(EntityTypeBuilder<DepartmentActivityType> builder)
        {
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);

            builder.HasOne(d => d.CreatedBy)
          .WithMany(p => p.DepartmentActivityTypeCreatedBy)
          .HasForeignKey(d => d.CreatedById)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("FK_DepartmentActivityType_Users_CreatedBy");

            builder.HasOne(d => d.ModifiedBy)
                .WithMany(p => p.DepartmentActivityTypeModifiedBy)
                .HasForeignKey(d => d.ModifiedById)
                .HasConstraintName("FK_DepartmentActivityType_Users_ModifiedBy");
        }
    }
}

using Mandegar.Models.Entities.Departments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mandegar.DataAccess.Configuration
{
    public class DepartmentActivity_Config : IEntityTypeConfiguration<DepartmentActivity>
    {
        public void Configure(EntityTypeBuilder<DepartmentActivity> builder)
        {
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Description).HasMaxLength(200);
            builder.Property(c => c.ActivityDescription).HasMaxLength(200);

            builder.HasOne(d => d.CreatedBy)
          .WithMany(p => p.DepartmentActivityCreatedBy)
          .HasForeignKey(d => d.CreatedById)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("FK_DepartmentActivity_Users_CreatedBy");

            builder.HasOne(d => d.ModifiedBy)
                .WithMany(p => p.DepartmentActivityModifiedBy)
                .HasForeignKey(d => d.ModifiedById)
                .HasConstraintName("FK_DepartmentActivity_Users_ModifiedBy");
        }
    }
}

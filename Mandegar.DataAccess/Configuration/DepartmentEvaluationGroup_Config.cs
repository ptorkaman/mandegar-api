using Mandegar.Models.Entities.Departments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mandegar.DataAccess.Configuration
{
    public class DepartmentEvaluationGroup_Config : IEntityTypeConfiguration<DepartmentEvaluationGroup>
    {
        public void Configure(EntityTypeBuilder<DepartmentEvaluationGroup> builder)
        {
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);

            builder.HasOne(d => d.CreatedBy)
         .WithMany(p => p.DepartmentEvaluationGroupCreatedBy)
         .HasForeignKey(d => d.CreatedById)
         .OnDelete(DeleteBehavior.ClientSetNull)
         .HasConstraintName("FK_DepartmentEvaluationGroup_Users_CreatedBy");

            builder.HasOne(d => d.ModifiedBy)
                .WithMany(p => p.DepartmentEvaluationGroupModifiedBy)
                .HasForeignKey(d => d.ModifiedById)
                .HasConstraintName("FK_DepartmentEvaluationGroup_Users_ModifiedBy");
        }
    }
}

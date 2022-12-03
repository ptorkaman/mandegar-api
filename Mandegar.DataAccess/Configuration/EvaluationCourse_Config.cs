using Mandegar.Models.Entities.Departments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mandegar.DataAccess.Configuration
{
    public class EvaluationCourse_Config : IEntityTypeConfiguration<EvaluationCourse>
    {
        public void Configure(EntityTypeBuilder<EvaluationCourse> builder)
        {
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);

            builder.HasOne(d => d.CreatedBy)
          .WithMany(p => p.EvaluationCourseCreatedBy)
          .HasForeignKey(d => d.CreatedById)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("FK_EvaluationCourse_Users_CreatedBy");

            builder.HasOne(d => d.ModifiedBy)
                .WithMany(p => p.EvaluationCourseModifiedBy)
                .HasForeignKey(d => d.ModifiedById)
                .HasConstraintName("FK_EvaluationCourse_Users_ModifiedBy");
        }
    }
}

using Mandegar.Models.Entities.BaseInfo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mandegar.DataAccess.Configuration
{
    public class StudyGrade_Config : IEntityTypeConfiguration<StudyGrade>
    {
        public void Configure(EntityTypeBuilder<StudyGrade> builder)
        {
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);


            builder.HasOne(d => d.CreatedBy)
          .WithMany(p => p.StudyGradeCreatedBy)
          .HasForeignKey(d => d.CreatedById)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("FK_StudyGrade_Users_CreatedBy");

            builder.HasOne(d => d.ModifiedBy)
                .WithMany(p => p.StudyGradeModifiedBy)
                .HasForeignKey(d => d.ModifiedById)
                .HasConstraintName("FK_StudyGrade_Users_ModifiedBy");
        }
    }
}

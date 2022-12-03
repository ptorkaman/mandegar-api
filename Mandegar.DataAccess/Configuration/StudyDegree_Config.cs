using Mandegar.Models.Entities.BaseInfo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mandegar.DataAccess.Configuration
{
    public class StudyDegree_Config : IEntityTypeConfiguration<StudyDegree>
    {
        public void Configure(EntityTypeBuilder<StudyDegree> builder)
        {
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);


            builder.HasOne(d => d.CreatedBy)
          .WithMany(p => p.StudyDegreeCreatedBy)
          .HasForeignKey(d => d.CreatedById)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("FK_StudyDegree_Users_CreatedBy");

            builder.HasOne(d => d.ModifiedBy)
                .WithMany(p => p.StudyDegreeModifiedBy)
                .HasForeignKey(d => d.ModifiedById)
                .HasConstraintName("FK_StudyDegree_Users_ModifiedBy");
        }
    }
}

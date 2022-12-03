using Mandegar.Models.Entities.BaseInfo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mandegar.DataAccess.Configuration
{
    public class StudyField_Config : IEntityTypeConfiguration<StudyField>
    {
        public void Configure(EntityTypeBuilder<StudyField> builder)
        {
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);


            builder.HasOne(d => d.CreatedBy)
          .WithMany(p => p.StudyFieldCreatedBy)
          .HasForeignKey(d => d.CreatedById)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("FK_StudyField_Users_CreatedBy");

            builder.HasOne(d => d.ModifiedBy)
                .WithMany(p => p.StudyFieldModifiedBy)
                .HasForeignKey(d => d.ModifiedById)
                .HasConstraintName("FK_StudyField_Users_ModifiedBy");
        }
    }
}

using Mandegar.Models.Entities.Personeli;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mandegar.DataAccess.Configuration
{
    public class EducationalQualification_Config : IEntityTypeConfiguration<EducationalQualification>
    {
        public void Configure(EntityTypeBuilder<EducationalQualification> builder)
        {
            builder.Property(c => c.CourseName).HasMaxLength(50);
            builder.Property(c => c.InstitutionName).HasMaxLength(50);

            builder.HasOne(c => c.Staff)
                .WithMany(c => c.EducationalQualifications)
                .HasForeignKey(c => c.StaffId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.CreatedBy)
          .WithMany(p => p.EducationalQualificationCreatedBy)
          .HasForeignKey(d => d.CreatedById)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("FK_EducationalQualification_Users_CreatedBy");

            builder.HasOne(d => d.ModifiedBy)
                .WithMany(p => p.EducationalQualificationModifiedBy)
                .HasForeignKey(d => d.ModifiedById)
                .HasConstraintName("FK_EducationalQualification_Users_ModifiedBy");
        }
    }
}

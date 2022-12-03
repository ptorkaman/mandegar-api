using Mandegar.Models.Entities.Personeli;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mandegar.DataAccess.Configuration
{
    public class WorkExperienceType_Config : IEntityTypeConfiguration<WorkExperienceType>
    {
        public void Configure(EntityTypeBuilder<WorkExperienceType> builder)
        {
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);

            builder.HasOne(d => d.CreatedBy)
          .WithMany(p => p.WorkExperienceTypeCreatedBy)
          .HasForeignKey(d => d.CreatedById)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("FK_WorkExperienceType_Users_CreatedBy");

            builder.HasOne(d => d.ModifiedBy)
                .WithMany(p => p.WorkExperienceTypeModifiedBy)
                .HasForeignKey(d => d.ModifiedById)
                .HasConstraintName("FK_WorkExperienceType_Users_ModifiedBy");
        }
    }
}

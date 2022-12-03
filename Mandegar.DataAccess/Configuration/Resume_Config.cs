using Mandegar.Models.Entities.Personeli;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mandegar.DataAccess.Configuration
{
    public class Resume_Config : IEntityTypeConfiguration<Resume>
    {
        public void Configure(EntityTypeBuilder<Resume> builder)
        {
            builder.Property(c => c.WorkPlaceName).IsRequired().HasMaxLength(100);
            builder.Property(c => c.WorkExperienceTypeId).IsRequired();
            builder.Property(c => c.PositionId).IsRequired();
            
            builder.HasOne(d => d.CreatedBy)
                  .WithMany(p => p.ResumeCreatedBy)
                  .HasForeignKey(d => d.CreatedById)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_Resume_Users_CreatedBy");

            builder.HasOne(d => d.ModifiedBy)
                .WithMany(p => p.ResumeModifiedBy)
                .HasForeignKey(d => d.ModifiedById)
                .HasConstraintName("FK_Resume_Users_ModifiedBy");
        }
    }
}

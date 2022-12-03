using Mandegar.Models.Entities.Personeli;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mandegar.DataAccess.Configuration
{
    public class Education_Config : IEntityTypeConfiguration<Education>
    {
        public void Configure(EntityTypeBuilder<Education> builder)
        {
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);

            builder.HasOne(d => d.CreatedBy)
          .WithMany(p => p.EducationCreatedBy)
          .HasForeignKey(d => d.CreatedById)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("FK_Education_Users_CreatedBy");

            builder.HasOne(d => d.ModifiedBy)
                .WithMany(p => p.EducationModifiedBy)
                .HasForeignKey(d => d.ModifiedById)
                .HasConstraintName("FK_Education_Users_ModifiedBy");
        }
    }
}

using Mandegar.Models.Entities.Personeli;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mandegar.DataAccess.Configuration
{
    public class ActivityField_Config : IEntityTypeConfiguration<ActivityField>
    {
        public void Configure(EntityTypeBuilder<ActivityField> builder)
        {
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);

            builder.HasOne(d => d.CreatedBy)
          .WithMany(p => p.ActivityFieldCreatedBy)
          .HasForeignKey(d => d.CreatedById)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("FK_ActivityField_Users_CreatedBy");

            builder.HasOne(d => d.ModifiedBy)
                .WithMany(p => p.ActivityFieldModifiedBy)
                .HasForeignKey(d => d.ModifiedById)
                .HasConstraintName("FK_ActivityField_Users_ModifiedBy");
        }
    }
}

using Mandegar.Models.Entities.Personeli;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mandegar.DataAccess.Configuration
{
    public class ActivityCase_Config : IEntityTypeConfiguration<ActivityCase>
    {
        public void Configure(EntityTypeBuilder<ActivityCase> builder)
        {
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);

            builder.HasOne(d => d.CreatedBy)
          .WithMany(p => p.ActivityCaseCreatedBy)
          .HasForeignKey(d => d.CreatedById)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("FK_ActivityCase_Users_CreatedBy");

            builder.HasOne(d => d.ModifiedBy)
                .WithMany(p => p.ActivityCaseModifiedBy)
                .HasForeignKey(d => d.ModifiedById)
                .HasConstraintName("FK_ActivityCase_Users_ModifiedBy");
        }
    }
}

using Mandegar.Models.Entities.Personeli;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mandegar.DataAccess.Configuration
{
    public class Activity_Config : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Subject).HasMaxLength(100);
            builder.Property(c => c.PublicationName).HasMaxLength(100);
            builder.Property(c => c.ActivityTypeId).IsRequired();
            builder.Property(c => c.ActivityCaseId).IsRequired();


            builder.HasOne(d => d.CreatedBy)
          .WithMany(p => p.ActivityCreatedBy)
          .HasForeignKey(d => d.CreatedById)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("FK_Activity_Users_CreatedBy");

            builder.HasOne(d => d.ModifiedBy)
                .WithMany(p => p.ActivityModifiedBy)
                .HasForeignKey(d => d.ModifiedById)
                .HasConstraintName("FK_Activity_Users_ModifiedBy");
        }
    }
}

using Mandegar.Models.Entities.Personeli;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mandegar.DataAccess.Configuration
{
    public class MilitaryServiceStatus_Config : IEntityTypeConfiguration<MilitaryServiceStatus>
    {
        public void Configure(EntityTypeBuilder<MilitaryServiceStatus> builder)
        {
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);

            builder.HasOne(d => d.CreatedBy)
          .WithMany(p => p.MilitaryServiceStatusCreatedBy)
          .HasForeignKey(d => d.CreatedById)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("FK_MilitaryServiceStatus_Users_CreatedBy");

            builder.HasOne(d => d.ModifiedBy)
                .WithMany(p => p.MilitaryServiceStatusModifiedBy)
                .HasForeignKey(d => d.ModifiedById)
                .HasConstraintName("FK_MilitaryServiceStatus_Users_ModifiedBy");
        }
    }
}

using Mandegar.Models.Entities.Personeli;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mandegar.DataAccess.Configuration
{
    public class StaffAddress_Config : IEntityTypeConfiguration<StaffAddress>
    {
        public void Configure(EntityTypeBuilder<StaffAddress> builder)
        {
            builder.Property(c => c.Phone).IsRequired().HasMaxLength(11);
            builder.Property(c => c.Mobile1).IsRequired().HasMaxLength(11);
            builder.Property(c => c.Mobile2).HasMaxLength(11);
            builder.Property(c => c.Address).IsRequired().HasMaxLength(200);
            builder.Property(c => c.OtherWorkPhone).HasMaxLength(11);
            builder.Property(c => c.OtherWorkName).HasMaxLength(50);
            builder.Property(c => c.Description).HasMaxLength(150);
            builder.Property(c => c.Email).IsRequired().HasMaxLength(100);

            builder.HasOne(d => d.CreatedBy)
          .WithMany(p => p.StaffAddressCreatedBy)
          .HasForeignKey(d => d.CreatedById)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("FK_StaffAddress_Users_CreatedBy");

            builder.HasOne(d => d.ModifiedBy)
                .WithMany(p => p.StaffAddressModifiedBy)
                .HasForeignKey(d => d.ModifiedById)
                .HasConstraintName("FK_StaffAddress_Users_ModifiedBy");

        }
    }
}

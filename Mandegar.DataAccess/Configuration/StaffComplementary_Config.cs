using Mandegar.Models.Entities.Personeli;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mandegar.DataAccess.Configuration
{
    public class StaffComplementary_Config : IEntityTypeConfiguration<StaffComplementary>
    {
        public void Configure(EntityTypeBuilder<StaffComplementary> builder)
        {
            builder.Property(c => c.CertificateNumber).HasMaxLength(32);
            builder.Property(c => c.InsuranceNumber).IsRequired().HasMaxLength(10);
            builder.Property(c => c.IdentitySerialNumber).HasMaxLength(12);
            builder.Property(c => c.ReligionId).IsRequired();
            builder.Property(c => c.MaritalStatusId).IsRequired();
            builder.Property(c => c.MilitaryServiceStatusId).IsRequired();
            builder.Property(c => c.InsuranceTypeId).IsRequired();

            builder.HasOne(d => d.CreatedBy)
          .WithMany(p => p.StaffComplementaryCreatedBy)
          .HasForeignKey(d => d.CreatedById)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("FK_StaffComplementary_Users_CreatedBy");

            builder.HasOne(d => d.ModifiedBy)
                .WithMany(p => p.StaffComplementaryModifiedBy)
                .HasForeignKey(d => d.ModifiedById)
                .HasConstraintName("FK_StaffComplementary_Users_ModifiedBy");
        }
    }
}

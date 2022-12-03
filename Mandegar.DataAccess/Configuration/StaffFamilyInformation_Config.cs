using Mandegar.Models.Entities.Personeli;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mandegar.DataAccess.Configuration
{
    public class StaffFamilyInformation_Config : IEntityTypeConfiguration<StaffFamilyInformation>
    {
        public void Configure(EntityTypeBuilder<StaffFamilyInformation> builder)
        {
            builder.Property(c => c.Name).IsRequired().HasMaxLength(32);
            builder.Property(c => c.Family).IsRequired().HasMaxLength(32);
            builder.Property(c => c.IdentityNumber).HasMaxLength(10);
            builder.Property(c => c.NationalCode).IsRequired().HasMaxLength(10);
            builder.Property(c => c.Phone).IsRequired().HasMaxLength(11);
            builder.Property(c => c.Mobile).IsRequired().HasMaxLength(11);
            builder.Property(c => c.WorkPhone).HasMaxLength(11);
            builder.Property(c => c.Description).HasMaxLength(150);
            builder.Property(c => c.Email).HasMaxLength(100);
            builder.Property(c => c.Job).HasMaxLength(50);
            builder.Property(c => c.WorkAddress).HasMaxLength(200);
            builder.Property(c => c.RelationId).IsRequired();

            builder.HasOne(d => d.CreatedBy)
                  .WithMany(p => p.StaffFamilyInformationCreatedBy)
                  .HasForeignKey(d => d.CreatedById)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_StaffFamilyInformation_Users_CreatedBy");

            builder.HasOne(d => d.ModifiedBy)
                .WithMany(p => p.StaffFamilyInformationModifiedBy)
                .HasForeignKey(d => d.ModifiedById)
                .HasConstraintName("FK_StaffFamilyInformation_Users_ModifiedBy");

        }
    }
}

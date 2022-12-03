using Mandegar.Models.Entities.Personeli;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mandegar.DataAccess.Configuration
{
    public class StaffFinancial_Config : IEntityTypeConfiguration<StaffFinancial>
    {
        public void Configure(EntityTypeBuilder<StaffFinancial> builder)
        {
            builder.Property(c => c.BankId).IsRequired();
            builder.Property(c => c.AccountNumber).IsRequired().HasMaxLength(20);
            builder.Property(c => c.Sheba).HasMaxLength(26);
            builder.Property(c => c.BranchName).HasMaxLength(32);

            builder.HasOne(d => d.CreatedBy)
          .WithMany(p => p.StaffFinancialCreatedBy)
          .HasForeignKey(d => d.CreatedById)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("FK_StaffFinancial_Users_CreatedBy");

            builder.HasOne(d => d.ModifiedBy)
                .WithMany(p => p.StaffFinancialModifiedBy)
                .HasForeignKey(d => d.ModifiedById)
                .HasConstraintName("FK_StaffFinancial_Users_ModifiedBy");
        }
    }
}

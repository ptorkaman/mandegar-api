using Mandegar.Models.Entities.Personeli;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mandegar.DataAccess.Configuration
{
    public class StaffDocument_Config : IEntityTypeConfiguration<StaffDocument>
    {
        public void Configure(EntityTypeBuilder<StaffDocument> builder)
        {
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);

            builder.HasOne(d => d.CreatedBy)
                  .WithMany(p => p.StaffDocumentCreatedBy)
                  .HasForeignKey(d => d.CreatedById)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_StaffDocument_Users_CreatedBy");

            builder.HasOne(d => d.ModifiedBy)
                .WithMany(p => p.StaffDocumentModifiedBy)
                .HasForeignKey(d => d.ModifiedById)
                .HasConstraintName("FK_StaffDocument_Users_ModifiedBy");
        }
    }
}

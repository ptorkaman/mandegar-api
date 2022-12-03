using Mandegar.Models.Entities.Personeli;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mandegar.DataAccess.Configuration
{
    public class Sacrifice_Config : IEntityTypeConfiguration<Sacrifice>
    {
        public void Configure(EntityTypeBuilder<Sacrifice> builder)
        {
            builder.HasOne(d => d.CreatedBy)
                              .WithMany(p => p.SacrificeCreatedBy)
                              .HasForeignKey(d => d.CreatedById)
                              .OnDelete(DeleteBehavior.ClientSetNull)
                              .HasConstraintName("FK_Sacrifice_Users_CreatedBy");

            builder.HasOne(d => d.ModifiedBy)
                .WithMany(p => p.SacrificeModifiedBy)
                .HasForeignKey(d => d.ModifiedById)
                .HasConstraintName("FK_Sacrifice_Users_ModifiedBy");
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Mandegar.Models.Entities.Personeli;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mandegar.DataAccess.Configuration
{
    public class Position_Config : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);

            builder.HasOne(d => d.CreatedBy)
          .WithMany(p => p.PositionCreatedBy)
          .HasForeignKey(d => d.CreatedById)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("FK_Position_Users_CreatedBy");

            builder.HasOne(d => d.ModifiedBy)
                .WithMany(p => p.PositionModifiedBy)
                .HasForeignKey(d => d.ModifiedById)
                .HasConstraintName("FK_Position_Users_ModifiedBy");
        }
    }
}

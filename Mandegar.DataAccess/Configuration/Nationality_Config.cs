using Mandegar.Models.Entities.Personeli;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mandegar.DataAccess.Configuration
{
    public class Nationality_Config : IEntityTypeConfiguration<Nationality>
    {
        public void Configure(EntityTypeBuilder<Nationality> builder)
        {
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);

            builder.HasOne(d => d.CreatedBy)
          .WithMany(p => p.NationalityCreatedBy)
          .HasForeignKey(d => d.CreatedById)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("FK_Nationality_Users_CreatedBy");

            builder.HasOne(d => d.ModifiedBy)
                .WithMany(p => p.NationalityModifiedBy)
                .HasForeignKey(d => d.ModifiedById)
                .HasConstraintName("FK_Nationality_Users_ModifiedBy");
        }
    }
}

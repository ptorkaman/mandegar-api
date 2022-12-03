using Mandegar.Models.Entities.Personeli;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mandegar.DataAccess.Configuration
{
    public class Cooperation_Config : IEntityTypeConfiguration<Cooperation>
    {
        public void Configure(EntityTypeBuilder<Cooperation> builder)
        {
            builder.Property(c => c.DepartmentId).IsRequired();
            builder.Property(c => c.CooperationTypeId).IsRequired();


            builder.HasOne(d => d.CreatedBy)
                   .WithMany(p => p.CooperationCreatedBy)
                   .HasForeignKey(d => d.CreatedById)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_Cooperation_Users_CreatedBy");

            builder.HasOne(d => d.ModifiedBy)
                .WithMany(p => p.CooperationModifiedBy)
                .HasForeignKey(d => d.ModifiedById)
                .HasConstraintName("FK_Cooperation_Users_ModifiedBy");
        }
    }
}

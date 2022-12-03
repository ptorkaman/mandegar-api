using Mandegar.Models.Entities.BaseInfo;
using Mandegar.Models.Entities.Departments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mandegar.DataAccess.Configuration
{
    public class SecretaryScore_Config : IEntityTypeConfiguration<SecretaryScore>
    {
        public void Configure(EntityTypeBuilder<SecretaryScore> builder)
        {
            builder.Property(c => c.Score).IsRequired();


            builder.HasOne(d => d.CreatedBy)
          .WithMany(p => p.SecretaryScoreCreatedBy)
          .HasForeignKey(d => d.CreatedById)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("FK_SecretaryScore_Users_CreatedBy");

            builder.HasOne(d => d.ModifiedBy)
                .WithMany(p => p.SecretaryScoreModifiedBy)
                .HasForeignKey(d => d.ModifiedById)
                .HasConstraintName("FK_SecretaryScore_Users_ModifiedBy");
        }
    }
}

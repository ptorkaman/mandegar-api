using Mandegar.Models.Entities.BaseInfo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mandegar.DataAccess.Configuration
{
    public class YearClass_Config : IEntityTypeConfiguration<YearClass>
    {
        public void Configure(EntityTypeBuilder<YearClass> builder)
        {



            builder.HasOne(d => d.CreatedBy)
          .WithMany(p => p.YearClassCreatedBy)
          .HasForeignKey(d => d.CreatedById)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("FK_YearClass_Users_CreatedBy");

            builder.HasOne(d => d.ModifiedBy)
                .WithMany(p => p.YearClassModifiedBy)
                .HasForeignKey(d => d.ModifiedById)
                .HasConstraintName("FK_YearClass_Users_ModifiedBy");
        }
    }
}

using Mandegar.Models.Entities.BaseInfo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mandegar.DataAccess.Configuration
{
    public class AcademicYear_Config : IEntityTypeConfiguration<AcademicYear>
    {
        public void Configure(EntityTypeBuilder<AcademicYear> builder)
        {
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);


            builder.HasOne(d => d.CreatedBy)
          .WithMany(p => p.AcademicYearCreatedBy)
          .HasForeignKey(d => d.CreatedById)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("FK_AcademicYear_Users_CreatedBy");

            builder.HasOne(d => d.ModifiedBy)
                .WithMany(p => p.AcademicYearModifiedBy)
                .HasForeignKey(d => d.ModifiedById)
                .HasConstraintName("FK_AcademicYear_Users_ModifiedBy");
        }
    }
}

using Mandegar.Models.Entities.Departments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mandegar.DataAccess.Configuration
{
    public class EvaluationIndicators_Config : IEntityTypeConfiguration<EvaluationIndicator>
    {
        public void Configure(EntityTypeBuilder<EvaluationIndicator> builder)
        {
            builder.Property(c => c.Question).IsRequired().HasMaxLength(200);
            builder.Property(c => c.ScoreCeiling).IsRequired();


            builder.HasOne(d => d.CreatedBy)
          .WithMany(p => p.EvaluationIndicatorsCreatedBy)
          .HasForeignKey(d => d.CreatedById)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("FK_EvaluationIndicators_Users_CreatedBy");

            builder.HasOne(d => d.ModifiedBy)
                .WithMany(p => p.EvaluationIndicatorsModifiedBy)
                .HasForeignKey(d => d.ModifiedById)
                .HasConstraintName("FK_EvaluationIndicators_Users_ModifiedBy");
        }
    }
}

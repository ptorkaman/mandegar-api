using Mandegar.Models.Entities.BaseInfo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mandegar.DataAccess.Configuration
{
    public class Lesson_Config : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);


            builder.HasOne(d => d.CreatedBy)
          .WithMany(p => p.LessonCreatedBy)
          .HasForeignKey(d => d.CreatedById)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("FK_Lesson_Users_CreatedBy");

            builder.HasOne(d => d.ModifiedBy)
                .WithMany(p => p.LessonModifiedBy)
                .HasForeignKey(d => d.ModifiedById)
                .HasConstraintName("FK_Lesson_Users_ModifiedBy");
        }
    }
}

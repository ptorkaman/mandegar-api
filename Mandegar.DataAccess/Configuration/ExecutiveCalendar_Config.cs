using Mandegar.Models.Entities.BaseInfo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mandegar.DataAccess.Configuration
{
    public class ExecutiveCalendar_Config : IEntityTypeConfiguration<ExecutiveCalendar>
    {
        public void Configure(EntityTypeBuilder<ExecutiveCalendar> builder)
        {
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);


            builder.HasOne(d => d.CreatedBy)
          .WithMany(p => p.ExecutiveCalendarCreatedBy)
          .HasForeignKey(d => d.CreatedById)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("FK_ExecutiveCalendar_Users_CreatedBy");

            builder.HasOne(d => d.ModifiedBy)
                .WithMany(p => p.ExecutiveCalendarModifiedBy)
                .HasForeignKey(d => d.ModifiedById)
                .HasConstraintName("FK_ExecutiveCalendar_Users_ModifiedBy");
        }
    }
}

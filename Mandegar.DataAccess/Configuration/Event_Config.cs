using Mandegar.Models.Entities.BaseInfo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mandegar.DataAccess.Configuration
{
    public class Event_Config : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);


            builder.HasOne(d => d.CreatedBy)
          .WithMany(p => p.EventCreatedBy)
          .HasForeignKey(d => d.CreatedById)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("FK_Event_Users_CreatedBy");

            builder.HasOne(d => d.ModifiedBy)
                .WithMany(p => p.EventModifiedBy)
                .HasForeignKey(d => d.ModifiedById)
                .HasConstraintName("FK_Event_Users_ModifiedBy");
        }
    }
}

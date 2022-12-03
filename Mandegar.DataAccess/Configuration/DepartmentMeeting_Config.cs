using Mandegar.Models.Entities.Departments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mandegar.DataAccess.Configuration
{
    public class DepartmentMeeting_Config : IEntityTypeConfiguration<DepartmentMeeting>
    {
        public void Configure(EntityTypeBuilder<DepartmentMeeting> builder)
        {
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);


            builder.HasOne(d => d.CreatedBy)
          .WithMany(p => p.DepartmentMeetingCreatedBy)
          .HasForeignKey(d => d.CreatedById)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("FK_DepartmentMeeting_Users_CreatedBy");

            builder.HasOne(d => d.ModifiedBy)
                .WithMany(p => p.DepartmentMeetingModifiedBy)
                .HasForeignKey(d => d.ModifiedById)
                .HasConstraintName("FK_DepartmentMeeting_Users_ModifiedBy");
        }
    }
}

using Mandegar.Models.Entities.Departments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mandegar.DataAccess.Configuration
{
    public class DepartmentMeetingAttendees_Config : IEntityTypeConfiguration<DepartmentMeetingAttendees>
    {
        public void Configure(EntityTypeBuilder<DepartmentMeetingAttendees> builder)
        {
            //builder.HasKey(ur => new { ur.DepartmentMemberId, ur.DepartmentMeetingId });
            builder.HasOne(d => d.CreatedBy)
         .WithMany(p => p.DepartmentMeetingAttendeesCreatedBy)
         .HasForeignKey(d => d.CreatedById)
         .OnDelete(DeleteBehavior.ClientSetNull)
         .HasConstraintName("FK_DepartmentMeetingAttendees_Users_CreatedBy");

            builder.HasOne(d => d.ModifiedBy)
                .WithMany(p => p.DepartmentMeetingAttendeesModifiedBy)
                .HasForeignKey(d => d.ModifiedById)
                .HasConstraintName("FK_DepartmentMeetingAttendees_Users_ModifiedBy");
        }
    }
}
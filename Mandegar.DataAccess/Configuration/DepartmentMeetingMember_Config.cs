using Mandegar.Models.Entities.Departments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mandegar.DataAccess.Configuration
{
    public class DepartmentMeetingMember_Config : IEntityTypeConfiguration<DepartmentMeetingMember>
    {
        public void Configure(EntityTypeBuilder<DepartmentMeetingMember> builder)
        {
            //builder.HasKey(ur => new { ur.DepartmentMeetingId, ur.DepartmentMemberId, ur.DepartmentId });

            builder.HasOne(c => c.DepartmentMeeting)
                  .WithMany(c => c.DepartmentMeetingMembers)
                  .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(c => c.Department)
                    .WithMany(c => c.DepartmentMeetingMembers)
                    .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.CreatedBy)
       .WithMany(p => p.DepartmentMeetingMemberCreatedBy)
       .HasForeignKey(d => d.CreatedById)
       .OnDelete(DeleteBehavior.ClientSetNull)
       .HasConstraintName("FK_DepartmentMeetingMember_Users_CreatedBy");

            builder.HasOne(d => d.ModifiedBy)
                .WithMany(p => p.DepartmentMeetingMemberModifiedBy)
                .HasForeignKey(d => d.ModifiedById)
                .HasConstraintName("FK_DepartmentMeetingMember_Users_ModifiedBy");
        }
    }
}
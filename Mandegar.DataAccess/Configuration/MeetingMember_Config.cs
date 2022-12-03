using Mandegar.Models.Entities.Departments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Mandegar.DataAccess.Configuration
{
    public class MeetingMember_Config : IEntityTypeConfiguration<MeetingMember>
    {
        public void Configure(EntityTypeBuilder<MeetingMember> builder)
        {

            builder.HasOne(d => d.CreatedBy)
          .WithMany(p => p.MeetingMemberCreatedBy)
          .HasForeignKey(d => d.CreatedById)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("FK_MeetingMember_Users_CreatedBy");

            builder.HasOne(d => d.ModifiedBy)
                .WithMany(p => p.MeetingMemberModifiedBy)
                .HasForeignKey(d => d.ModifiedById)
                .HasConstraintName("FK_MeetingMember_Users_ModifiedBy");
        }
    }
}

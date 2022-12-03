using Mandegar.Models.Entities.Departments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mandegar.DataAccess.Configuration
{
    public class DepartmentActivityMember_Config : IEntityTypeConfiguration<DepartmentActivityMember>
    {
        public void Configure(EntityTypeBuilder<DepartmentActivityMember> builder)
        {
            builder.HasKey(ur => new { ur.DepartmentMemberId, ur.DepartmentActivityId });

            builder.HasOne(c => c.DepartmentMember)
                .WithMany(c => c.DepartmentActivityMembers)
                .OnDelete(DeleteBehavior.ClientSetNull);


            builder.HasOne(c => c.DepartmentActivity)
                .WithMany(c => c.DepartmentActivityMembers)
                .OnDelete(DeleteBehavior.ClientSetNull);

        }
    }
}
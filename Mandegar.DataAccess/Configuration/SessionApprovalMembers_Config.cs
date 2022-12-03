using Mandegar.Models.Entities.Departments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandegar.DataAccess.Configuration
{
    public class SessionApprovalMembers_Config : IEntityTypeConfiguration<SessionApprovalMembers>
    {
        public void Configure(EntityTypeBuilder<SessionApprovalMembers> builder)
        {

            builder.HasOne(d => d.CreatedBy)
          .WithMany(p => p.SessionApprovalMembersCreatedBy)
          .HasForeignKey(d => d.CreatedById)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("FK_SessionApprovalMembers_Users_CreatedBy");

            builder.HasOne(d => d.ModifiedBy)
                .WithMany(p => p.SessionApprovalMembersModifiedBy)
                .HasForeignKey(d => d.ModifiedById)
                .HasConstraintName("FK_SessionApprovalMembers_Users_ModifiedBy");
        }
    }
}

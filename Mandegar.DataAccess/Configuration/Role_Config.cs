using Mandegar.Models.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Mandegar.DataAccess.Configuration
{
    public class Role_Config : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasOne(d => d.CreatedBy)
                      .WithMany(p => p.RoleCreatedBy)
                      .HasForeignKey(d => d.CreatedById)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("FK_Role_Users_CreatedBy");

            builder.HasOne(d => d.ModifiedBy)
                .WithMany(p => p.RoleModifiedBy)
                .HasForeignKey(d => d.ModifiedById)
                .HasConstraintName("FK_Role_Users_ModifiedBy");
        }
    }
}


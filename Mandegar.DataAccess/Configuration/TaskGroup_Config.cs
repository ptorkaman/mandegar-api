using Mandegar.Models.Entities.Personeli;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mandegar.DataAccess.Configuration
{
    internal class TaskGroup_Config : IEntityTypeConfiguration<TaskGroup>
    {
        public void Configure(EntityTypeBuilder<TaskGroup> builder)
        {
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);

            builder.HasOne(d => d.CreatedBy)
            .WithMany(p => p.TaskGroupCreatedBy)
            .HasForeignKey(d => d.CreatedById)
            .HasConstraintName("FK_TaskGroup_Users_CreatedBy");

            builder.HasOne(d => d.ModifiedBy)
                .WithMany(p => p.TaskGroupModifiedBy)
                .HasForeignKey(d => d.ModifiedById)
                .HasConstraintName("FK_TaskGroup_Users_ModifiedBy");
        }
    }
}

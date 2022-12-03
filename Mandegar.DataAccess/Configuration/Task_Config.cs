using Mandegar.Models.Entities.Personeli;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mandegar.DataAccess.Configuration
{
    public class Task_Config : IEntityTypeConfiguration<Tasks>
    {
        public void Configure(EntityTypeBuilder<Tasks> builder)
        {
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
            builder.HasOne(c => c.TaskGroup).WithMany(c => c.Tasks).OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.TaskGroup)
                  .WithMany(p => p.Tasks)
                  .HasForeignKey(d => d.TaskGroupId)
                  .HasConstraintName("FK_Task_TaskGroup");

            builder.HasOne(d => d.CreatedBy)
                     .WithMany(p => p.TaskCreatedBy)
                     .HasForeignKey(d => d.CreatedById)
                     .OnDelete(DeleteBehavior.ClientSetNull)
                     .HasConstraintName("FK_Task_Users_CreatedBy");

            builder.HasOne(d => d.ModifiedBy)
                .WithMany(p => p.TaskModifiedBy)
                .HasForeignKey(d => d.ModifiedById)
                .HasConstraintName("FK_Task_Users_ModifiedBy");
        }
    }
}

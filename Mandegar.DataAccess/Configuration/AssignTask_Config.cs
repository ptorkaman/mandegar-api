using Mandegar.Models.Entities.Personeli;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mandegar.DataAccess.Configuration
{
    public class AssignTask_Config : IEntityTypeConfiguration<AssignTask>
    {
        public void Configure(EntityTypeBuilder<AssignTask> builder)
        {
            builder.HasKey(ur => new { ur.TaskId, ur.PositionId });
        }
    }
}
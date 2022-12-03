using Mandegar.Models.Entities.Personeli;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mandegar.DataAccess.Configuration
{
    public class AssignPosition_Config : IEntityTypeConfiguration<AssignPosition>
    {
        public void Configure(EntityTypeBuilder<AssignPosition> builder)
        {
            builder.HasKey(ur => new { ur.StaffId, ur.PositionId });
        }
    }
}

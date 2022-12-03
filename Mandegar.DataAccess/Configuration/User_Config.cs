using Mandegar.Models.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mandegar.DataAccess.Configuration
{
    public class User_Config : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(e => e.Users)
            .WithOne(e => e.ModifiedBy)
            .HasForeignKey(e => e.ModifiedById);
        }
    }
}


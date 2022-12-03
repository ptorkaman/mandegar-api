using Mandegar.Models.Entities.Personeli;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mandegar.DataAccess.Configuration
{
    public class Staff_Config : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Family).IsRequired().HasMaxLength(100);
            builder.Property(c => c.FatherName).IsRequired().HasMaxLength(100);
            builder.Property(c => c.BirthDate).IsRequired();
            builder.Property(c => c.NationalCode).IsRequired().HasMaxLength(10);
            builder.Property(c => c.Gender).IsRequired();

            builder.Property(c => c.IdentityNumber).HasMaxLength(10);
            builder.Property(c => c.PersonneliCode).HasMaxLength(32);

            builder.HasOne(d => d.CreatedBy)
          .WithMany(p => p.StaffCreatedBy)
          .HasForeignKey(d => d.CreatedById)
          .OnDelete(DeleteBehavior.ClientSetNull)
          .HasConstraintName("FK_Staff_Users_CreatedBy");

            builder.HasOne(d => d.ModifiedBy)
                .WithMany(p => p.StaffModifiedBy)
                .HasForeignKey(d => d.ModifiedById)
                .HasConstraintName("FK_Staff_Users_ModifiedBy");

        }
    }
}

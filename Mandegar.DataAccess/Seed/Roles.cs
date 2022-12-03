using Mandegar.Models.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace Mandegar.DataAccess.Seed
{
    public static class Roles
    {
        public static void RolesSeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
           new Role()
           {
               Id = -1,
               CreatedById = 1,
               Name = "کاربران عادی",
               ShowInList = false
           }
           );

            modelBuilder.Entity<Role>().HasData(
              new Role()
              {
                  Id = 1,
                  CreatedById = 1,
                  Name = "مدیر ارشد",
                  ShowInList = false
              }
              );

            modelBuilder.Entity<RolePermission>().HasData(
            new RolePermission() { PermissionId = 1, RoleId = 1 },
            new RolePermission() { PermissionId = -1, RoleId = -1 }
            );
        }
    }
}
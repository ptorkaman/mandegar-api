using Mandegar.Models.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace Mandegar.DataAccess.Seed
{
    public static class Users
    {
        public static void UsersSeed(this ModelBuilder modelBuilder)
        {
            var superAdminUser = new User()
            {
                Id = 1,
                IsActive = true,
                Username = "mandegar",
                Password = "aUMRrPiiPVPyDld0loRhog=="
            };
            modelBuilder.Entity<User>().HasData(
               superAdminUser
               );

            modelBuilder.Entity<Profile>().HasData(
                new Profile()
                {
                    Id = 1,
                    Name = "ادمین",
                    Family = "سیستم",
                    Email = "-",
                    UserId = 1
                }
                );


            modelBuilder.Entity<UserRole>().HasData(
               new UserRole() { UserId = 1, RoleId = 1 }
               );

        }
    }
}

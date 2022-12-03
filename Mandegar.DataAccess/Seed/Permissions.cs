using Mandegar.Models.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace Mandegar.DataAccess.Seed
{
    public static class Permissions
    {
        public static void PermissionsSeed(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Permission>().HasData(
                new Permission() { Id = -1, ShowInList = false, Index = 0, Name = "کاربر عادی" },
                new Permission() { Id = 1, ShowInList = false, Index = 0, Name = "مدیر ارشد" },
                new Permission() { Id = 2, Index = 0, Name = "مدیر" },
                new Permission() { Id = 3, Index = 0, Name = "پنل مدیریت" },

            #region Users
                new Permission() { Id = 4, Index = 1, Name = "مدیریت کاربران", ParentId = 3 },
                new Permission() { Id = 5, Index = 1, Name = "افزودن کاربر", ParentId = 3 },
                new Permission() { Id = 6, Index = 1, Name = "ویرایش کاربر", ParentId = 3 },
                new Permission() { Id = 7, Index = 1, Name = "حذف کاربر", ParentId = 3 },
            #endregion

            #region Role
                new Permission() { Id = 27, Index = 2, Name = "مدیریت نقش‌ها", ParentId = 3 },
                new Permission() { Id = 28, Index = 2, Name = "افزودن نقش", ParentId = 3 },
                new Permission() { Id = 29, Index = 2, Name = "ویرایش نقش", ParentId = 3 },
                new Permission() { Id = 30, Index = 2, Name = "حذف نقش", ParentId = 3 }

            #endregion

          
                );

        }
    }
}

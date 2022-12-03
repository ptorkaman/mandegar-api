using Mandegar.Models.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace Mandegar.DataAccess.QueryFilter
{
    public static class Users
    {
        public static void UsersQueryFilter(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasQueryFilter(u => !u.IsDeleted);
        }
    }
}

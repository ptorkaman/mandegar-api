using Mandegar.Models.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace Mandegar.DataAccess.QueryFilter
{
    public static class Roles
    {
        public static void RolesQueryFilter(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasQueryFilter(r => r.Id != 1 && r.Id != -1 && !r.IsDeleted);
        }
    }
}

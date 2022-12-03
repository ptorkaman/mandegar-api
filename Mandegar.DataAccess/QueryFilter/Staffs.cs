using Mandegar.Models.Entities.Personeli;
using Microsoft.EntityFrameworkCore;

namespace Mandegar.DataAccess.QueryFilter
{
    public static class Staffs
    {
        public static void StaffsQueryFilter(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Staff>().HasQueryFilter(u => !u.IsDeleted);
        }
    }
}

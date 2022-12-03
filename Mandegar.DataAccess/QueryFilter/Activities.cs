using Mandegar.Models.Entities.Personeli;
using Microsoft.EntityFrameworkCore;

namespace Mandegar.DataAccess.QueryFilter
{
    public static class Activities
    {
        public static void ActivityQueryFilter(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activity>().HasQueryFilter(u => !u.IsDeleted);
        }
    }
}

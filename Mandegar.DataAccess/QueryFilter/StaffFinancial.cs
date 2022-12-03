using Mandegar.Models.Entities.Personeli;
using Microsoft.EntityFrameworkCore;

namespace Mandegar.DataAccess.QueryFilter
{
    public static class StaffFinancials
    {
        public static void StaffFinancialQueryFilter(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StaffFinancial>().HasQueryFilter(u => !u.IsDeleted);
        }
    }
}

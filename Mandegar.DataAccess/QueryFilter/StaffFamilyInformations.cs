using Mandegar.Models.Entities.Personeli;
using Microsoft.EntityFrameworkCore;

namespace Mandegar.DataAccess.QueryFilter
{
    public static class StaffFamilyInformations
    {
        public static void StaffFamilyInformationQueryFilter(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StaffFamilyInformation>().HasQueryFilter(u => !u.IsDeleted);
        }
    }
}

using Mandegar.Models.Entities.Personeli;
using Microsoft.EntityFrameworkCore;

namespace Mandegar.DataAccess.QueryFilter
{
    public static class Resumes
    {
        public static void ResumeeQueryFilter(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resume>().HasQueryFilter(u => !u.IsDeleted);
        }
    }
}

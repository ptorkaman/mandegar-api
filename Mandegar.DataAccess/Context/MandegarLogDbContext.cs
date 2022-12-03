using Mandegar.Models.Entities.Log;
using Microsoft.EntityFrameworkCore;

namespace Mandegar.DataAccess
{
    public class MandegarLogDbContext : DbContext
    {
        public MandegarLogDbContext(DbContextOptions<MandegarLogDbContext> options) : base(options)
        {

        }

        public virtual DbSet<ExceptionLog> ExceptionLogs { get; set; }

        public virtual DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}

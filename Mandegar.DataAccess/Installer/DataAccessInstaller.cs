using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mandegar.DataAccess
{
    public static class DataAccessInstaller
    {
        public static void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MandegarDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("MandegarDbContext"))
                );

            services.AddDbContext<MandegarLogDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("MandegarLogDbContext"))
                );

        }
    }
}

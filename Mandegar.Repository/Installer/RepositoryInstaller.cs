using Mandegar.Repository.Repositories.Impeliments;
using Mandegar.Repository.Repositories.Interfaces;
using Mandegar.Repository.UnitOfWork;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mandegar.Repository.Installer
{
    public static class RepositoryInstaller
    {
        public static void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUow, Uow>();

            services.AddScoped<ILogExceptionRepository, LogExceptionRepository>();
        }
    }
}

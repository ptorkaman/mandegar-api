using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Mandegar.StartupConfiguration
{
    public static class Installer
    {
        public static void Install(IServiceCollection services, IConfiguration configuration)
        {
            Mandegar.DataAccess.DataAccessInstaller.Install(services, configuration);
            Mandegar.Repository.Installer.RepositoryInstaller.Install(services, configuration);
            Mandegar.Utilities.UtilityInstaller.Install(services, configuration);
            Mandegar.Utilities.UtilityInstaller.ConfigureServices(services);
            Mandegar.Services.Installer.ServiceInstaller.Install(services, configuration);
        }
    }
}

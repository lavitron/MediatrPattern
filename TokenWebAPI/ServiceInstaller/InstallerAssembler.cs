using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TokenWebAPI.ServiceInstaller
{
    public static class InstallerAssembler
    {
        public static void AddInstallerServicesAssembler(this IServiceCollection services,
            IConfiguration configuration)
        {
            var installers = typeof(Startup).Assembly.ExportedTypes
                .Where(p => typeof(IInstaller).IsAssignableFrom(p) && !p.IsInterface && !p.IsAbstract)
                .Select(Activator.CreateInstance)
                .Cast<IInstaller>()
                .ToList();
            installers.ForEach(installer => installer.InstallServices(services, configuration));
        }
    }
}
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TokenInfrastructure.DependencyInjection;
namespace TokenWebAPI.ServiceInstaller
{
    public class InfrastructureInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddJwtAuthentication(configuration);
            services.AddDatabase();
            services.AddCorsOption();
            services.AddFluentValidator();
            services.AddServices();
            services.AddMediator();
        }
    }
}
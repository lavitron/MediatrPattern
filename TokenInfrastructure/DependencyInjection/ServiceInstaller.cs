using Microsoft.Extensions.DependencyInjection;
using TokenBusiness.Abstract;
using TokenBusiness.Concrete;
using TokenDAL.Security.Helper;

namespace TokenInfrastructure.DependencyInjection
{
    public static class ServiceInstaller
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITokenHelper, TokenHelper>();
        }
    }
}
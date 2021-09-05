using Microsoft.Extensions.DependencyInjection;

namespace TokenInfrastructure.DependencyInjection
{
    public static class CorsInstaller
    {
        public static void AddCorsOption(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });
        }
    }
}
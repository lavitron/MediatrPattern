using Core.Utility.Mapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TokenDAL.Context;

namespace TokenInfrastructure.DependencyInjection
{
    public static class DbInstaller
    {
        public static void AddDatabase(this IServiceCollection services)
        {
            services.AddSingleton<IMapper, Mapper>();

            services.AddDbContextPool<ITokenDbContext, TokenDbContext>(options =>
                options.UseSqlServer("Server=.\\SQLExpress;Database=TokenDb;Trusted_Connection=True;"));
        }
    }
}
using System;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace TokenInfrastructure.DependencyInjection
{
    public static class MediatrInstaller
    {
        public static void AddMediator(this IServiceCollection services)
        {
            var assembler = AppDomain.CurrentDomain.Load("TokenBusiness");
            services.AddMediatR(assembler);
        }
    }
}
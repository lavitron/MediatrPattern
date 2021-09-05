using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using TokenInfrastructure.Middleware;

namespace TokenInfrastructure.DependencyInjection
{
    public static class FluentValidationInstaller
    {
        public static void AddFluentValidator(this IServiceCollection services)
        {
            //Fluent validation settings
            var assembler = AppDomain.CurrentDomain.Load("TokenBusiness");
            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
                options.Filters.Add<ValidationFilter>();
            }).AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssembly(assembler));

            //[ApiController] tag prevent default BadRequest return
            services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);
        }
    }
}
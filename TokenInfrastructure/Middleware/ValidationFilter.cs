using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TokenInfrastructure.Middleware
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            //Before Controller
            if (!context.ModelState.IsValid)
            {
                var errorsInModelState = context.ModelState.Where(p => p.Value.Errors.Count > 0)
                    .ToDictionary(keyValuePair => keyValuePair.Key, keyValuePair => keyValuePair.Value.Errors
                        .Select(p => p.ErrorMessage)).ToArray();
                var list = errorsInModelState.SelectMany(error => error.Value).ToList();
                context.Result = new OkObjectResult(new {code = (HttpStatusCode) 1002, message = list, type = "error"});
                return;
            }

            await next();
            //Controller
        }
    }
}
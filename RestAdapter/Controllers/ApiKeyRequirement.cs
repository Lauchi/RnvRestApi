using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace RestAdapter.Controllers
{
    public class ApiKeyRequirement : AuthorizationHandler<ApiKeyRequirement>, IAuthorizationRequirement
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ApiKeyRequirement requirement)
        {
            var authorizationHandlerContext = context.Resource as AuthorizationFilterContext;
            if (authorizationHandlerContext != null)
            {
                var headerDictionary = authorizationHandlerContext.HttpContext.Request.Headers;
                var apiKey = headerDictionary["Authorization"].ToString();
                if (apiKey == "81ef63c8-7d9d-44e3-a06d-328eedd88676")
                {
                    context.Succeed(requirement);
                }
                else
                {
                    authorizationHandlerContext.Result = new UnauthorizedResult();
                    context.Succeed(requirement);
                }
                return Task.CompletedTask;
            }

            context.Fail();
            return Task.CompletedTask;
        }
    }
}
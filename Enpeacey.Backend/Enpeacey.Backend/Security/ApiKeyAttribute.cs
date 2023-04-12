using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Enpeacey.Backend.Security
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ApiKeyAttribute : Attribute, IAuthorizationFilter
    {
        private const string API_KEY_HEADER_NAME = "X-API-Key";
        private const string API_KEY_QUERY_NAME = "api_key";

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string apiKey = null;

            if (context.HttpContext.Request.Headers.TryGetValue(API_KEY_HEADER_NAME, out var headerValue))
            {
                apiKey = headerValue.ToString();
            }
            else if (context.HttpContext.Request.Query.TryGetValue(API_KEY_QUERY_NAME, out var queryValue))
            {
                apiKey = queryValue.ToString();
            }

            if (string.IsNullOrEmpty(apiKey))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            // TODO: Validate the API key here
        }
    }
}

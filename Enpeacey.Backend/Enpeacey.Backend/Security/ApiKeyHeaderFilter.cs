using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

namespace Enpeacey.Backend.Security
{

    public class ApiKeyHeaderFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            // Add the X-API-Key header to the request headers
            if (!operation.Parameters.Any(x => x.Name == "X-API-Key"))
            {
                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = "X-API-Key",
                    In = ParameterLocation.Header,
                    Description = "API Key",
                    Required = true,
                    Schema = new OpenApiSchema
                    {
                        Type = "string",
                        Default = new OpenApiString("my-api-key")
                    }
                });
            }
        }
    }
}

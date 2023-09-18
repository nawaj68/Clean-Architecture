using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace TaskManagement.Backend.Filters;

public class AuthResponsesOperationFilter : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        var globalAttributes = context.ApiDescription.ActionDescriptor.FilterDescriptors.Select(p => p.Filter);
        var controllerAttributes = context.MethodInfo?.DeclaringType?.GetCustomAttributes(true);
        var methodAttributes = context.MethodInfo?.GetCustomAttributes(true);
        var authAttributes  = globalAttributes
            .Union(controllerAttributes ?? throw new InvalidOperationException())
            .Union(methodAttributes!)
            .OfType<AuthorizeAttribute>()
            .ToList();
        if (authAttributes.Any())
            operation.Responses.TryAdd("401", new OpenApiResponse { Description = "Unauthorized" });
    }

}
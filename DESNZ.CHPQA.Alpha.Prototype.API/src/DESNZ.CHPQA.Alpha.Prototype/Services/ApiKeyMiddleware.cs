using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace DESNZ.CHPQA.Alpha.Prototype.Services;

public class ApiKeyMiddleware : IMiddleware
{
    private readonly IConfiguration _configuration;

    public ApiKeyMiddleware(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        if (!context.Request.Headers.TryGetValue("x-api-key", out var apiKeyHeaderValues))
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync("API key is missing.");
            return;
        }

        var apiKey = apiKeyHeaderValues.FirstOrDefault();
        if (apiKey != _configuration["ApiKey"])
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync("Invalid API key.");
            return;
        }

        await next(context);
    }
}

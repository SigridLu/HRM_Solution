using System;
using System.Net;

namespace Onboarding_API.Utility
{
    public class MiddlewareExtension
    {
        private readonly RequestDelegate _next;

        public MiddlewareExtension(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        public async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.ContentType = "text/plain"; // "application/json"
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await httpContext.Response.WriteAsync($"Status Code = {httpContext.Response.StatusCode}\nError Message = {exception.Message}");
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensionExtensions
    {
        public static IApplicationBuilder UseMiddlewareClassTemplate(this IApplicationBuilder builder)
        {

            return builder.UseMiddleware<MiddlewareExtension>();
        }
    }
}


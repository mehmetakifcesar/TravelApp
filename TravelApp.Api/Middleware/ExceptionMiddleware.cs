using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Threading.Tasks;
using TravelApp.Entity.Result;
using TravelApp.Helper.Exceptions;

namespace TravelApp.Api.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                if (e.GetType() == typeof(FieldValidationException))
                {
                    List<string> errors = e.Data["FieldValidationErrors"] as List<string>;

                    httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    httpContext.Response.ContentType = "application/json";
                    await httpContext.Response.WriteAsJsonAsync(ErrorResult<FieldValidationException>.FieldValidationError(errors));
                }
                else if (e.GetType() == typeof(SecurityTokenSignatureKeyNotFoundException))
                {
                    httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    httpContext.Response.ContentType = "application/json";
                    await httpContext.Response.WriteAsJsonAsync(ErrorResult<FieldValidationException>.TokenError(ErrorInfo.TokenError()));

                }
                else if (e.GetType() == typeof(SecurityTokenInvalidSignatureException))
                {
                    httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    httpContext.Response.ContentType = "application/json";
                    await httpContext.Response.WriteAsJsonAsync(ErrorResult<FieldValidationException>.TokenError(ErrorInfo.TokenError()));
                }
                else if (e.GetType() == typeof(SecurityTokenInvalidSignatureException))
                {
                    httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    httpContext.Response.ContentType = "application/json";
                    await httpContext.Response.WriteAsJsonAsync(ErrorResult<FieldValidationException>.TokenError(ErrorInfo.TokenError()));
                }
                else if (e.GetType() == typeof(SecurityTokenValidationException))
                {
                    httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    httpContext.Response.ContentType = "application/json";
                    await httpContext.Response.WriteAsJsonAsync(ErrorResult<FieldValidationException>.TokenError(ErrorInfo.TokenError()));
                }

                else if (e.GetType() == typeof(TokenNotFoundException))
                {
                    httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    httpContext.Response.ContentType = "application/json";
                    await httpContext.Response.WriteAsJsonAsync(ErrorResult<FieldValidationException>.TokenNotFoundError(ErrorInfo.TokenNotFoundError()));

                }
                else
                {
                    httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    httpContext.Response.ContentType = "application/json";
                    await httpContext.Response.WriteAsJsonAsync(ErrorResult<bool>.Error(ErrorInfo.Error()));
                }

            }

        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}

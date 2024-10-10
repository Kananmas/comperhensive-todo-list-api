using comperhensive_todo_list_api.Services.Interface.General;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace comperhensive_todo_list_api.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class JwtChecker
    {
        private readonly RequestDelegate _next;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IJwtServices _jwtServices;

        public JwtChecker(RequestDelegate next , IJwtServices jwtServices , IHttpContextAccessor contextAccessor)
        {
            _next = next;
            _jwtServices = jwtServices;
            _contextAccessor = contextAccessor;
           
        }

        public Task Invoke(HttpContext httpContext)
        {
            var jwtToken = _contextAccessor.HttpContext.Request.Headers.Authorization.ToString();
            var requestPath = _contextAccessor.HttpContext.Request.Path.ToString();
            if (requestPath.EndsWith("signin") || requestPath.EndsWith("signup") ) return _next(httpContext);
            if(_jwtServices.IsTokenExpired(jwtToken))
            {
                throw new UnauthorizedAccessException();
            }
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseJwtMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<JwtChecker>();
        }
    }
}

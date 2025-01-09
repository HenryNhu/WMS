using Microsoft.AspNetCore.Http;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace WMS_new.Middleware
{
    public class SessionChecker
    {
        private readonly RequestDelegate _next;
        public SessionChecker(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path == "/" || context.Request.Path.StartsWithSegments("/Users/Login"))
            {
                await _next(context);
                return;
            }

            var session_Login = context.Session.GetString("User");
            if (string.IsNullOrEmpty(session_Login))
            {
                context.Response.Redirect("/Users/Login/");
                return;
            }
            await _next(context);
        }
    }
}

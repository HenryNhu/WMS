namespace WMS_new.Middleware
{
    public class LoggedChecker
    {
        private readonly RequestDelegate _next;
        public LoggedChecker(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var session_Login = context.Session.GetString("User");
            if (context.Request.Path.StartsWithSegments("/Home/Index"))
            {
                await _next(context);
                return;
            }
            if (!string.IsNullOrEmpty(session_Login) && context.Request.Path.StartsWithSegments("/Users/Login/"))
            {
                context.Response.Redirect("/Home/Index/");
                return;
            }
            await _next(context);
        }
    }
}

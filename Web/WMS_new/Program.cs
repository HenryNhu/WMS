using WMS_new.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//HttpClient
builder.Services.AddHttpClient();
//Cache
builder.Services.AddDistributedMemoryCache();
//Session
builder.Services.AddSession(cfg =>
{
    //Session's name
    cfg.Cookie.Name = "WorkingUser";
    //Remainning session's time
    cfg.IdleTimeout = new TimeSpan(0, 60, 0);
    //this cookie is essential
    cfg.Cookie.IsEssential = true;
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
//use Https
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
//use session
app.UseSession();
//use middleware 
app.UseMiddleware<SessionChecker>();
app.UseMiddleware<LoggedChecker>();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Users}/{action=Login}/{id?}");

app.Run();

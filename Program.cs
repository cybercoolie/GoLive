using GoLive.GoDBContexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Configuration.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").AddEnvironmentVariables();

//SQL Server
var SQLServerconnectionString = builder.Configuration.GetConnectionString("SQLServerConnection");
if(SQLServerconnectionString != null)
{
   builder.Services.AddDbContext<GoDbContext>(Options => Options.UseSqlServer(SQLServerconnectionString));
}
//PostgreSQl Server
var PostgreSQlconnectionString = builder.Configuration.GetConnectionString("PostgreSQLConnection");
if (PostgreSQlconnectionString != null)
{
    builder.Services.AddDbContext<GoDbContext>(Options => Options.UseNpgsql(PostgreSQlconnectionString));
}
//MySQL server
var MySQlconnectionString = builder.Configuration.GetConnectionString("MySQLConnection");
if (MySQlconnectionString != null)
{
    builder.Services.AddDbContext<GoDbContext>(Options => Options.UseMySql(MySQlconnectionString, ServerVersion.AutoDetect(MySQlconnectionString)));
}
// Add services to the container.


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

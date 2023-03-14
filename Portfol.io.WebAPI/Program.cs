using Portfol.io.Application;
using Portfol.io.Persistence;
using Portfol.io.WebAPI.Middlewares;
using Portfol.io.WebAPI.Middlewares.ExceptionMiddleware;
using Portfol.io.WebAPI.ServiceConfigurations;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

var connectionString = builder.Configuration.GetConnectionString("PostgreSQL");
builder.Services.AddPersistence(connectionString!);
builder.Services.AddApplication();

builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
builder.Services.AddMvc();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerMiddleware();

builder.Services.AddAuthenticationMiddleware();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var context = serviceProvider.GetRequiredService<PortfolioDbContext>();
        DbInitializer.Initialize(context);
    }
    catch (Exception e)
    {
        var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
        logger.LogError(e, $"An error occured while initializing the database: {e.Message}");
    }
}

app.UseExceptionMiddleware();

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllers();

app.Run();

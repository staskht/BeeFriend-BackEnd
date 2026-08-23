using BeeFriend.Infrastructure.DbContext;
using BeeFriend.Web.Middleware;
using BeeFriend.Web.StartupExtensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.ConfigureServices(builder.Configuration);



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();

    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    await db.Database.EnsureDeletedAsync();
    await db.Database.MigrateAsync();
}

app.UseExceptionHandlingMiddleware();

app.UseHsts();
app.UseHttpsRedirection();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "1.0");
});

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

using Microsoft.EntityFrameworkCore;
using MinimalAPI.Controller;
using MinimalAPI.Models;
using System.Data.Common;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("Sqlite"));
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

var dbHandler = new AppDbHandler(app);

app.Run();



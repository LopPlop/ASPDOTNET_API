using Microsoft.EntityFrameworkCore;
using MinimalAPI.Controller;
using MinimalAPI.Controller.Context;
using MinimalAPI.Controller.Repositories;
using MinimalAPI.Data.Interfaces;
using System.Data.Common;


var builder = WebApplication.CreateBuilder(args);




builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("Sqlite"));
});
builder.Services.AddScoped<IHotelRepository, HotelRepository>();




var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

var dbHandler = new AppDbHandler(app);

app.Run();



using Microsoft.EntityFrameworkCore;
using MinimalAPI.Models;

namespace MinimalAPI.Controller
{
    public class AppDbHandler
    {

        public AppDbHandler(WebApplication app)
        {


            // Весь список
            app.MapGet("/hotels", async (AppDbContext db) => await db.Hotels.ToListAsync());


            // Отель по id
            app.MapGet("/hotels/{id}", async (AppDbContext db, int id) =>
            {
                var hotels = await db.Hotels.ToListAsync();
                return hotels[id];
            }
            );


            // Добавление
            app.MapPost("/hotels", async (AppDbContext db, Hotel hotel) =>
            {
                await db.Hotels.AddAsync(hotel);
                await db.SaveChangesAsync();
            });


            // Изменение
            app.MapPut("/hotels", (AppDbContext db, Hotel hotel) =>
            {
                db.Hotels.Update(hotel);
                db.SaveChanges();
            });


            // Удаление
            app.MapDelete("/hotels", async (AppDbContext db, int id) =>
            {
                var hotels = await db.Hotels.ToListAsync();
                foreach (Hotel h in hotels)
                    if (h.Id == id)
                    {
                        db.Hotels.Remove(h);
                        await db.SaveChangesAsync();
                    }
            });
        }
    }
}

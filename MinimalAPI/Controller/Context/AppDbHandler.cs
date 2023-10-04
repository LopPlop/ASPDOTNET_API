using Microsoft.EntityFrameworkCore;
using MinimalAPI.Data;
using MinimalAPI.Data.Interfaces;
using MinimalAPI.Data.Models;
using System.Linq;

namespace MinimalAPI.Controller.Context
{
    public class AppDbHandler
    {

        public AppDbHandler(WebApplication app)
        {
            // Весь список
            app.MapGet("/hotels", async (IHotelRepository repository) => Results.Extensions.Xml(await repository.GetHotelsAsync()))
                .Produces<List<Hotel>>(StatusCodes.Status200OK)
                .WithName("Gets all hotels")
                .WithTags("Getters");


            // Отель по id
            app.MapGet("/hotels/{id}", async (IHotelRepository repository, int id) => Results.Extensions.Xml(await repository.GetHotelByIdAsync(id)))
                .Produces<Hotel>(StatusCodes.Status200OK)
                .WithName("Gests hotel by id")
                .WithTags("Getters");


            // Отель по названию
            app.MapGet("/hotels/search/name/{query}", async (IHotelRepository repository, string query) => Results.Extensions.Xml(await repository.GetHotelsByName(query)))
                .Produces<List<Hotel>>(StatusCodes.Status200OK)
                .WithName("Gets hotels by name")
                .WithTags("Getters")
                .ExcludeFromDescription();


            // Добавление
            app.MapPost("/hotels", async (IHotelRepository repository, Hotel hotel) => await repository.InsertHotelAsync(hotel))
                .Accepts<Hotel>("application/json")
                .Produces<Hotel>(StatusCodes.Status201Created)
                .WithName("Create Hotel")
                .WithTags("Creators"); 


            // Изменение
            app.MapPut("/hotels", (IHotelRepository repository, Hotel hotel) => repository.UpdateHotelAsync(hotel))
                .Accepts<Hotel>("application/json")
                .WithName("Update hotel")
                .WithTags("Updaters");


            // Удаление
            app.MapDelete("/hotels/{id}", async (IHotelRepository repository, int id) => {
                await repository.DeleteHotelAsync(id);
                await repository.SaveChangesAsync();
                })
                .WithName("Delete hotel")
                .WithTags("Deleters");
        }
    }
}

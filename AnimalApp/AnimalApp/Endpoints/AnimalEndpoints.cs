using AnimalApp.Database;
using AnimalApp.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AnimalApp.Endpoints;

public static class AnimalEndpoints
{
    public static void MapAnimalEndpoints(this WebApplication app)
    {
        //pobieranie listy zwierzat
        app.MapGet("/animals", (MockDb db) =>
        {
            var animals = db.Animals;
    
            return Results.Ok(animals);
        });
        
        //pobieranie konkretnego zwierzecia po id
        app.MapGet("/animals/{id}", (MockDb db, int id) =>
        {
            var animals = db.Animals;

            var animal = animals.FirstOrDefault(a => a.Id == id);
            if (animal == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(animal);
        });
        
        //dodawanie zwierzęcia
        app.MapPost("/animals", (MockDb db, Animal animal) =>
        {
            
            var animals = db.Animals;
            
            animals.Add(animal);
            
            return Results.Created($"/animals/{animal.Id}", animal);
        });
        
        //edycja zwierzęcia
        app.MapPut("/animals/{id}", (MockDb db, int id, Animal updatedAnimal) =>
        {
            var animals = db.Animals;
            
            var animal = animals.FirstOrDefault(a => a.Id == id);
            if (animal == null)
            {
                return Results.NotFound();
            }

            animal.Name = updatedAnimal.Name;
            animal.Category = updatedAnimal.Category;
            animal.Weight = updatedAnimal.Weight;
            animal.FurColor = updatedAnimal.FurColor;
            return Results.NoContent();
        });

        //usuwanie zwierzęcia
        app.MapDelete("/animals/{id}", (MockDb db, int id) =>
        {

            var animals = db.Animals;
            
            var animal = animals.FirstOrDefault(a => a.Id == id);
            if (animal == null)
            {
                return Results.NotFound();
            }

            animals.Remove(animal);

            return Results.NoContent();
        });
    }
}
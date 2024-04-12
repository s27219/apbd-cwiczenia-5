using AnimalApp.Database;
using AnimalApp.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AnimalApp.Endpoints;

public static class AnimalEndpoints
{
    public static void MapAnimalEndpoints(this WebApplication app)
    {
        //pobieranie listy zwierzat
        app.MapGet("/animals", () =>
        {
            var animals = new MockDb().Animals;
    
            return Results.Ok(animals);
        });
        
        //pobieranie konkretnego zwierzecia po id
        app.MapGet("/animals/{id}", (int id) =>
        {
            var animals = new MockDb().Animals;
            var animal = animals.FirstOrDefault(a => a.Id == id);
            if (animal == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(animal);
        });
        
        //dodawanie zwierzęcia
        app.MapPost("/animals", (Animal animal) =>
        {
            var animals = new MockDb().Animals;
            animals.Add(animal);
            
            return Results.Created($"/animals/{animal.Id}", animal);
        });
        
        //edycja zwierzęcia
        app.MapPut("/animals/{id}", (int id, Animal updatedAnimal) =>
        {
            var animals = new MockDb().Animals;
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
        app.MapDelete("/animals/{id}", (int id) =>
        {
            var animals = new MockDb().Animals;
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
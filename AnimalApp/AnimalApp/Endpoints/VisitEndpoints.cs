using AnimalApp.Database;
using AnimalApp.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AnimalApp.Endpoints;

public static class VisitEndpoints
{
    public static void MapVisitEndpoints(this WebApplication app)
    {
        //pobieranie listy wizyt powiązanych z danym zwierzeciem
        app.MapGet("/animals/{animalId}/visits", (int animalId) =>
        {
            var visits = new MockDb().Visits.Where(v => v.VisitedAnimal.Id == animalId).ToList();
            return Results.Ok(visits);
        });
        
        //dodawanie nowych wizyt
        app.MapPost("/visits", (Visit visit) =>
        {
            var visits = new MockDb().Visits;
            visits.Add(visit);
            //leave empty?
            return Results.Created("", visit);
        });
    }
}
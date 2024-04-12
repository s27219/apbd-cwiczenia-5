using AnimalApp.Database;
using AnimalApp.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AnimalApp.Endpoints;

public static class VisitEndpoints
{
    public static void MapVisitEndpoints(this WebApplication app)
    {
        //pobieranie listy wizyt powiązanych z danym zwierzeciem
        app.MapGet("/animals/{animalId}/visits", (MockDb db, int animalId) =>
        {
            var visits = db.Visits.Where(v => v.VisitedAnimal.Id == animalId).ToList();
            return Results.Ok(visits);
        });
        
        //dodawanie nowych wizyt
        app.MapPost("/visits", (MockDb db, Visit visit) =>
        {
            var visits = db.Visits;
            visits.Add(visit);
            return Results.Created("", visit);
        });
    }
}
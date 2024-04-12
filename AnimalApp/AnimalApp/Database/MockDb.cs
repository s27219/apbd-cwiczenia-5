using AnimalApp.Models;

namespace AnimalApp.Database;

public class MockDb
{
    public List<Animal> Animals { get; set; } = new List<Animal>();
    public List<Visit> Visits { get; set; } = new List<Visit>();

    public MockDb()
    {
        Animals.Add(new Animal { Id = 1, Name = "Bella", Category = "Dog", Weight = 22.5, FurColor = "Brown" });
        Animals.Add(new Animal { Id = 2, Name = "Max", Category = "Cat", Weight = 5.0, FurColor = "Black" });
        Animals.Add(new Animal { Id = 3, Name = "Luna", Category = "Dog", Weight = 18.0, FurColor = "Grey" });
        Animals.Add(new Animal { Id = 4, Name = "Charlie", Category = "Cat", Weight = 4.5, FurColor = "Orange" });
        Animals.Add(new Animal { Id = 5, Name = "Lucy", Category = "Dog", Weight = 23.0, FurColor = "Black" });
        Animals.Add(new Animal { Id = 6, Name = "Simba", Category = "Cat", Weight = 6.0, FurColor = "White" });
        Animals.Add(new Animal { Id = 7, Name = "Molly", Category = "Dog", Weight = 17.0, FurColor = "Spotted" });
        
        Visits.Add(new Visit
        {
            VisitDate = DateTime.Now.AddDays(-1),
            VisitedAnimal = Animals.FirstOrDefault(a => a.Id == 1),
            Description = "Annual vaccination",
            Price = 100.00M
        });
        
        
    }
}
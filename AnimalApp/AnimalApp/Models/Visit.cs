namespace AnimalApp.Models;

public class Visit
{
    public DateTime VisitDate { get; set; }
    public Animal VisitedAnimal { get; set; }
    public String Description  { get; set; }
    public decimal Price { get; set; }
}
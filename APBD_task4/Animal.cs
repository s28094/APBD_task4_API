namespace APBD_task4;

public class Animal
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public double Weight { get; set; }
    public string FurColor { get; set; }
    public List<Visit> Visits { get; set; } = new List<Visit>();
}

public class Visit
{
    public int Id { get; set; }
    public DateTime VisitDate { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
}
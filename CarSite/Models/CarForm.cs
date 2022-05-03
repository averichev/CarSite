namespace CarSite.Models;

public class CarForm
{
    public int Id { get; set; }
    public string Name { get; set; }
    public byte SeatsCount { get; set; }
    public string Url { get; set; }
    public int? Body { get; set; }
    public int? Brand { get; set; }

    public string? BrandName { get; set; }
    public string? BodyName { get; set; }
}
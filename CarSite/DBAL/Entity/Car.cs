using System.ComponentModel.DataAnnotations.Schema;

namespace CarSite.DBAL.Entity;

[Table("Car")]
public class Car
{
    public int Id { get; set; }
    public string Name { get; set; }
    public byte SeatsCount { get; set; }
    public string Url { get; set; }
}
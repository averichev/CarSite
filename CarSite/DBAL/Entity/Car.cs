using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarSite.DBAL.Entity;

[Table("Car")]
public class Car
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public byte SeatsCount { get; set; }
    public string Url { get; set; }
    public Brand? Brand { get; set; }
    public Body? Body { get; set; }
    public int? BrandId { get; set; }
    public int? BodyId { get; set; }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarSite.DBAL.Entity;

[Table("Brand")]
public class Brand
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
}
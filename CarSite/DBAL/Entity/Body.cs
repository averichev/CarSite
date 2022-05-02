using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarSite.DBAL.Entity;

[Table("Body")]
public class Body
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
}
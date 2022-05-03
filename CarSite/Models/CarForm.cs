using System.ComponentModel.DataAnnotations;

namespace CarSite.Models;

public class CarForm
{
    public int Id { get; set; }
    public string Name { get; set; }

    [Range(1, 12, ErrorMessage = "Число мест сидения должно быть между {1} и {2}")]
    public byte SeatsCount { get; set; }

    [StringLength(1000)] 
    [Url]
    [RegularExpression(@"^https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}((\.(ru))\b)([-a-zA-Z0-9()@:%_\+.~#?&//=]*)$", ErrorMessage = "Домен должен быть в зоне .ru")]
    public string? Url { get; set; }
    public int? Body { get; set; }
    public int? Brand { get; set; }
    public string? BrandName { get; set; }
    public string? BodyName { get; set; }
}
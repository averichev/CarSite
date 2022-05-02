namespace CarSite.Models;

public class BrandList
{
    public BrandList()
    {
        
    }
    public BrandList(IEnumerable<DBAL.Entity.Brand> brands)
    {
        var list = brands
            .Select(
                brand => new Brand
                {
                    Id = brand.Id,
                    Name = brand.Name
                })
            .ToList();

        List = list;
    }

    public IEnumerable<Brand> List { get; set; }
}
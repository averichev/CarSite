using CarSite.Models;

namespace CarSite.DBAL.Repository.Implementation;

public class BrandRepository : IBrandRepository
{
    private readonly CarsDbContext _context;

    public BrandRepository(CarsDbContext context)
    {
        _context = context;
    }
    public async Task AddBrand(Brand brand)
    {
        _context.Brands.Add(new Entity.Brand
        {
            Name = brand.Name
        });
        await _context.SaveChangesAsync();
    }
}
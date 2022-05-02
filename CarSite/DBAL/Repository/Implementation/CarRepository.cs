using CarSite.Models;
using Microsoft.EntityFrameworkCore;

namespace CarSite.DBAL.Repository.Implementation;

public class CarRepository : ICarRepository
{
    private readonly CarsDbContext _context;

    public CarRepository(CarsDbContext context)
    {
        _context = context;
    }

    public async Task AddCar(CarForm car)
    {
        _context.Cars.Add(new Entity.Car
        {
            Name = car.Name,
            Url = car.Url,
            SeatsCount = car.SeatsCount
        });
        await _context.SaveChangesAsync();
    }

    public async Task<List<Entity.Car>> List()
    {
        return await _context.Cars.ToListAsync();
    }

    public async Task<CarFormData> Form()
    {
        var bodies = await _context.Bodies.ToListAsync();
        var brands = await _context.Brands.ToListAsync();
        var result = new CarFormData
        {
            Bodies = new BodyList(bodies),
            Brands = new BrandList(brands)
        };
        return result;
    }
}
using CarSite.DBAL.Entity;
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
        _context.Cars.Add(new Car
        {
            Name = car.Name,
            Url = car.Url,
            SeatsCount = car.SeatsCount,
            BodyId = car.Body,
            BrandId = car.Brand
        });
        await _context.SaveChangesAsync();
    }

    public async Task<List<Car>> List()
    {
        var brands = _context.Brands;
        var bodies = _context.Bodies;
        var data = await _context
            .Cars
            .GroupJoin(
                brands,
                n => n.BrandId,
                b => b.Id,
                (c, b) => new
                {
                    Car = c,
                    Brand = b
                }
            )
            .SelectMany(
                n => n.Brand.DefaultIfEmpty(),
                (n, b) => new
                {
                    n.Car,
                    Brand = b
                })
            .GroupJoin(
                bodies,
                n => n.Car.BodyId,
                b => b.Id,
                (c, b) => new
                {
                    Car = c,
                    Body = b
                }
            )
            .SelectMany(
                n => n.Body.DefaultIfEmpty(),
                (n, b) => new
                {
                    n.Car,
                    Body = b
                })
            .ToListAsync();
        var result = data.Select(n => n.Car.Car).ToList();
        return result;
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

    public async Task<Car> Detail(int id)
    {
        return await _context.Cars.FirstOrDefaultAsync(n => n.Id == id) ?? throw new InvalidOperationException();
    }

    public async Task Delete(int id)
    {
        var entity = await Detail(id);
        _context.Cars
            .Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Edit(CarForm car)
    {
        var entity = await Detail(car.Id);
        entity.Name = car.Name;
        entity.Url = car.Url;
        entity.SeatsCount = car.SeatsCount;
        entity.BodyId = car.Body;
        entity.BrandId = car.Brand;
        await _context.SaveChangesAsync();
    }
}
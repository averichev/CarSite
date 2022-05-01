using CarSite.DBAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace CarSite.DBAL;

public class CarsDbContext : DbContext
{
    public CarsDbContext(DbContextOptions<CarsDbContext> options) : base(options)
    {
    }
    
    public DbSet<Car> Cars { get; set; }
    public DbSet<Brand> Brands { get; set; }
}
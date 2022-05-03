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
    public DbSet<Body> Bodies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>()
            .HasOne(n => n.Brand)
            .WithMany()
            .HasForeignKey(n => n.BrandId);
        modelBuilder.Entity<Car>()
            .HasOne(n => n.Body)
            .WithMany()
            .HasForeignKey(n => n.BodyId);
    }
}
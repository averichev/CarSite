using CarSite.Models;

namespace CarSite.DBAL.Repository;

public interface IBrandRepository
{
    Task AddBrand(Brand brand);
    Task<List<Entity.Brand>> List();
}
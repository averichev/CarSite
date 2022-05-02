using CarSite.Models;

namespace CarSite.DBAL.Repository;

public interface IBodyRepository
{
    Task AddBody(Body body);
    Task<List<Entity.Body>> List();
}
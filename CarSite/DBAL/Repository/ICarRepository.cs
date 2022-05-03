using CarSite.Models;

namespace CarSite.DBAL.Repository;

public interface ICarRepository
{
    Task AddCar(CarForm car);
    Task<List<Entity.Car>> List();
    Task<CarFormData> Form();
    Task<Entity.Car> Detail(int id);
    Task Edit(CarForm car);
}
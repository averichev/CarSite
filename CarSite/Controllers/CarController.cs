using CarSite.DBAL.Repository;
using CarSite.Models;
using Microsoft.AspNetCore.Mvc;
using ActionResult = CarSite.Models.ActionResult;

namespace CarSite.Controllers;

[Route("api/cars")]
public class CarsController : Controller
{
    private readonly ICarRepository _repository;

    public CarsController(ICarRepository repository)
    {
        _repository = repository;
    }
    [HttpPost]
    [Route("add")]
    public async Task<IActionResult> Add([FromBody] CarForm car)
    {
        await _repository.AddCar(car);
        return Json(new ActionResult
        {
            IsSuccess = true
        });
    }
    
    [HttpGet]
    public async Task<CarList> List()
    {
        var entities = await _repository.List();
        var cars = entities.Select(n => new CarForm
        {
            Id = n.Id,
            Name = n.Name,
            Url = n.Url,
            SeatsCount = n.SeatsCount
        });
        return new CarList
        {
            List = cars
        };
    }

    [HttpGet]
    [Route("form")]
    public async Task<CarFormData> Form()
    {
        var result = await _repository.Form();
        return result;
    }
    
    [HttpGet]
    [Route("{id:int}")]
    public async Task<CarForm> Detail(int id)
    {
        var car = await _repository.Detail(id);
        return new CarForm
        {
            Id = car.Id,
            Name = car.Name,
            Url = car.Url,
            SeatsCount = car.SeatsCount,
            Body = car.BodyId,
            Brand = car.BrandId
        };
    }
    
    [HttpPost]
    [Route("{id:int}/edit")]
    public async Task Edit([FromBody] CarForm car, int id)
    {
        car.Id = id;
        await _repository.Edit(car);
    }
    
    [HttpDelete]
    [Route("{id:int}/delete")]
    public async Task Delete(int id)
    {
        await _repository.Delete(id);
    }
}
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
}
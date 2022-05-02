using CarSite.DBAL.Repository;
using CarSite.Models;
using Microsoft.AspNetCore.Mvc;
using ActionResult = CarSite.Models.ActionResult;

namespace CarSite.Controllers;

[Route("api/bodies")]
public class BodiesController : Controller
{
    private readonly IBodyRepository _repository;

    public BodiesController(IBodyRepository repository)
    {
        _repository = repository;
    }
    [HttpPost]
    [Route("add")]
    public async Task<IActionResult> Add([FromBody] Body body)
    {
        await _repository.AddBody(body);
        return Json(new ActionResult
        {
            IsSuccess = true
        });
    }
    
    [HttpGet]
    public async Task<BodyList> List()
    {
        var entities = await _repository.List();
        var bodies = entities.Select(n => new Body
        {
            Id = n.Id,
            Name = n.Name
        });
        return new BodyList
        {
            List = bodies
        };
    }
}
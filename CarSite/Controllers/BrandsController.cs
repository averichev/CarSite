using CarSite.DBAL.Repository;
using CarSite.Models;
using Microsoft.AspNetCore.Mvc;
using ActionResult = CarSite.Models.ActionResult;

namespace CarSite.Controllers;

[Route("api/brands")]
public class BrandsController : Controller
{
    private readonly IBrandRepository _repository;

    public BrandsController(IBrandRepository repository)
    {
        _repository = repository;
    }
    [HttpPost]
    [Route("add")]
    public async Task<IActionResult> Add([FromBody] Brand brand)
    {
        await _repository.AddBrand(brand);
        return Json(new ActionResult
        {
            IsSuccess = true
        });
    }
    
    [HttpGet]
    public async Task<BrandList> List()
    {
        var entities = await _repository.List();
        var brands = entities.Select(n => new Brand
        {
            Id = n.Id,
            Name = n.Name
        });
        return new BrandList
        {
            List = brands
        };
    }
}
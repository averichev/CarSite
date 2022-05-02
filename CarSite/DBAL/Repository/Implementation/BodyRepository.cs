using CarSite.Models;
using Microsoft.EntityFrameworkCore;

namespace CarSite.DBAL.Repository.Implementation;

public class BodyRepository : IBodyRepository
{
    private readonly CarsDbContext _context;

    public BodyRepository(CarsDbContext context)
    {
        _context = context;
    }
    public async Task AddBody(Body body)
    {
        _context.Bodies.Add(new Entity.Body
        {
            Name = body.Name
        });
        await _context.SaveChangesAsync();
    }
    
    public async Task<List<Entity.Body>> List()
    {
        return await _context.Bodies.ToListAsync();
    }
}
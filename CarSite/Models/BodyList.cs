namespace CarSite.Models;

public class BodyList
{
    public BodyList()
    {
        
    }
    public BodyList(IEnumerable<DBAL.Entity.Body> bodies)
    {
        var list = bodies
            .Select(
                body => new Body
                {
                    Id = body.Id,
                    Name = body.Name
                })
            .ToList();

        List = list;
    }

    public IEnumerable<Body> List { get; set; }
}
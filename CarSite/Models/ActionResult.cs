namespace CarSite.Models;

public class ActionResult
{
    public bool IsSuccess { get; set; }
    public IEnumerable<string> Errors { get; set; }
}
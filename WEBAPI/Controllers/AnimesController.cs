using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[ApiController]
[Route("[controller]")]
public class AnimesController : ControllerBase
{
    private readonly AnimeContext _context;

    public AnimesController(AnimeContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IEnumerable<Anime> Get()
    {
        return _context.Animes.ToList();
    }
}
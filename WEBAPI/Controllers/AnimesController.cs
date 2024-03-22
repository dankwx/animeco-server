using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

    [HttpPost]
    public async Task<ActionResult<Anime>> PostAnime(Anime anime)
    {
        _context.Animes.Add(anime);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { id = anime.id }, anime);
    }
}

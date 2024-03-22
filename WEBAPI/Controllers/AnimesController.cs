using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


[ApiController]
[Route("[controller]")]
public class AnimesController : ControllerBase
{
    private readonly AnimeContext _context;

    public AnimesController(AnimeContext context)
    {
        _context = context;
    }

    [HttpGet] // pega todos animes
    public IEnumerable<Anime> Get()
    {
        return _context.Animes.ToList();
    }

    [HttpGet("{id}")] // pega anime por id
    public async Task<ActionResult<Anime>> GetAnime(int id)
    {
        var anime = await _context.Animes.FindAsync(id);

        if (anime == null)
        {
            return NotFound();
        }

        return anime;
    }

    [HttpPost] // adicionar anime
    public async Task<ActionResult<Anime>> PostAnime(Anime anime)
    {
        _context.Animes.Add(anime);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { id = anime.id }, anime);
    }

    [HttpPut("{id}")] // atualiza informações do anime por ID
    public async Task<IActionResult> PutAnime(int id, Anime anime)
    {
        if (id != anime.id)
        {
            return BadRequest();
        }

        _context.Entry(anime).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!AnimeExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }



    [HttpDelete("{id}")] // remove anime
    public async Task<IActionResult> DeleteAnime(int id)
    {
        var anime = await _context.Animes.FindAsync(id);
        if (anime == null)
        {
            return NotFound();
        }

        _context.Animes.Remove(anime);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool AnimeExists(int id)
    {
        return _context.Animes.Any(e => e.id == id);
    }
}

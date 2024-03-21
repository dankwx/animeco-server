using Microsoft.EntityFrameworkCore;

public class AnimeContext : DbContext
{
    public AnimeContext(DbContextOptions<AnimeContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Anime>().ToTable("animes");
    }

    public DbSet<Anime> Animes { get; set; }
}
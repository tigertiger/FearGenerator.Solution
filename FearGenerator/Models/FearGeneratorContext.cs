using Microsoft.EntityFrameworkCore;

namespace FearGenerator.Models
{
  public class FearGeneratorContext : DbContext
  {
    public DbSet<Subgenre> Subgenres { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<MoviesSubgenres> MoviesSubgenres {get; set;}
    public DbSet<Human> Humans {get; set;}
    public DbSet<HumansMovies> HumansMovies {get; set;}

    public FearGeneratorContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}
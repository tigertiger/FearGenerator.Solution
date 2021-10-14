using System.Collections.Generic;

namespace FearGenerator.Models
{
  public class Movie
  {
    public Movie()
    {
      this.JoinEntities = new HashSet<MoviesSubgenres>();
      this.HumansJoinEntities = new HashSet<HumansMovies>();
    }
    public int MovieId { get; set; }
    public string Title { get; set; }
    public string Rating { get; set; }
    public int Year { get; set; }
    public int Stars { get; set; }
    // public int SubgenreId { get; set; }
    // public virtual Subgenre Subgenre { get; set; }
    public virtual ICollection<MoviesSubgenres> JoinEntities {get; set;}
    public virtual ICollection<HumansMovies> HumansJoinEntities {get; set;}
  }
}
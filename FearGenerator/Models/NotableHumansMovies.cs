using System.Collections.Generic;

namespace FearGenerator.Models
{
  public class NotableHumansMovies {
    public int NotableHumansMoviesId {get; set;}
    public int MovieId {get; set;}
    public int NotableHumansId {get; set;}
    public virtual Movie Movie {get; set;}
    public virtual NotableHuman NotableHuman {get; set;}
  }
}
using System.Collections.Generic;

namespace FearGenerator.Models
{
  public class HumansMovies {
    public int HumansMoviesId {get; set;}
    public int MovieId {get; set;}
    public int HumanId {get; set;}
    public virtual Movie Movie {get; set;}
    public virtual Human Human {get; set;}
  }
}
using System.Collections.Generic;

namespace FearGenerator.Models
{
  public class MoviesSubgenres{
    public int MoviesSubgenresId {get; set;}
    public int MovieId {get; set;}
    public int SubgenreId {get; set;}
    public virtual Movie Movie {get; set;}
    public virtual Subgenre Subgenre {get; set;}
  }
}
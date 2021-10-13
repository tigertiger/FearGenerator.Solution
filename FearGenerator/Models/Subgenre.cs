using System.Collections.Generic;

namespace FearGenerator.Models
{
  public class Subgenre
  {
    public Subgenre()
    {
      this.JoinEntities = new HashSet<MoviesSubgenres>();
    }

    public int SubgenreId {get; set;}
    public string Name {get; set;}
    public string Description { get; set;}
    public virtual ICollection<MoviesSubgenres> JoinEntities { get; set;}
  }
}
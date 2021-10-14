using System.Collections.Generic;

namespace FearGenerator.Models
{
  public class Human
  {
    public Human()
    {
      this.HumansJoinEntities = new HashSet<HumansMovies>();
    }
    public int HumanId {get; set; }
    public string HumanName { get; set; }
    public string Role { get; set; }
    public string Notes {get; set;}
    public virtual ICollection<HumansMovies> HumansJoinEntities {get; set;}
  }
}
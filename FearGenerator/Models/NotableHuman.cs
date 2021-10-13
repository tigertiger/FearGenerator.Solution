using System.Collections.Generic;

namespace FearGenerator.Models
{
  public class NotableHuman
  {
    public NotableHuman()
    {
      this.HumansJoinEntities = new HashSet<NotableHumansMovies>();
    }
    public int NotableHumanId {get; set; }
    public string HumanName { get; set; }
    public string Roll { get; set; }
    public virtual ICollection<NotableHumansMovies> HumansJoinEntities {get; set;}
  }
}
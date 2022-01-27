using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTime.Domain
{
  public class Concert
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public int BandId { get; set; }
    public DateTime Date { get; set; }
    public int VenueId { get; set; }
    public virtual Venue Venue { get; set; }
    public virtual ICollection<Band> Bands { get; set; }
  }
}

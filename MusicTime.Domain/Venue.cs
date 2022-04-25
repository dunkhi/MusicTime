using MusicTime.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTime.Domain
{
  public class Venue
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public int Capacity { get; set; }
    public virtual string Photo { get; set; }
    public VenueType Type { get; set; }
    public virtual ICollection<PostalAddress> PostalAdddress { get; set; }
    public virtual ICollection<Concert> Concerts { get; set; }
  }
}

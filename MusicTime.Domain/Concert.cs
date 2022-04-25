using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTime.Domain
{
  public class Concert
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual string Photo { get; set; }
    public int BandId { get; set; }

    [Column(TypeName = "Date")]
    [DataType(DataType.Date)]
    public DateTime ConcertDate { get; set; }
    public int VenueId { get; set; }
    public int TicketsAvailable { get; set; }
    public virtual Venue Venue { get; set; }
    public virtual Band Band { get; set; }
    public virtual ICollection<Ticket> Tickets { get; set; }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTime.Domain
{
  public class TicketCategory
  {
    public int Id { get; set; }
    public string Description { get; set; }
    public Decimal Price { get; set; }
    public string Area { get; set; }
  }
}

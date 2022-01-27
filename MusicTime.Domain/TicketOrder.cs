using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTime.Domain
{
  public class TicketOrder
  {
    public int Id { get; set; }
    public int CustomerOrderId { get; set; }
    public int TicketId { get; set; }
  }
}

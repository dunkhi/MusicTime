using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTime.Domain
{
  public class CustomerOrder
  {
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal FinalPrice { get; set; }
    public ICollection<Ticket> TicketOrder { get; set; }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTime.Domain
{
  public class Ticket
  {
    public int Id { get; set; }
    public string SerialNumber { get; set; }
    public string Seat { get; set; }
    public string Area { get; set; }
    public int ConcertId { get; set; }
    public virtual Concert Concert { get; set; }
    public Decimal Price { get; set; }
    public DateTime PurchaseDate { get; set; }
  }
}

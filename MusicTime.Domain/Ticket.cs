using MusicTime.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTime.Domain
{
  public class Ticket
  {
    public int Id { get; set; }
    public int ConcertId { get; set; }
    public int ProductId { get; set; }
    public string Seat { get; set; }
    public string Area { get; set; }
    public TicketTypeEnum TicketType { get; set; }
    public virtual Concert Concert { get; set; }
    public virtual Product Product { get; set; }
    public double Price { get; set; }
  }
}

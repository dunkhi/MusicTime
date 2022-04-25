using MusicTime.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTime.Domain.View_Models
{
  public class ProductTicketViewModel
  {
    public int TicketId { get; set; }
    public int ProductId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Seat { get; set; }
    public string Area { get; set; }
    public TicketTypeEnum TicketType { get; set; }
    public double Price { get; set; }
  }
}

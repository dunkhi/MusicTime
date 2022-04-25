using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTime.Domain
{
  public class OrderDetails
  {
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int CustomerOrderId { get; set; }
    public int Quantity { get; set; }
    public double UnitCost { get; set; }
    public virtual CustomerOrder CustomerOrder { get; set; }
    public virtual Product Product { get; set; }
  }
}

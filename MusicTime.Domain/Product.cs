using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTime.Domain
{
  public class Product
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public ICollection<Ticket> Tickets { get; set; }
    public ICollection<Product> Products { get; set; }
    public ICollection<OrderDetails> OrderDetails { get; set; }
  }
}

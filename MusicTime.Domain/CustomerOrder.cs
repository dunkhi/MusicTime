using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTime.Domain
{
  public class CustomerOrder
  {
    public int Id { get; set; }
    public int CustomerId { get; set; }
    [Column(TypeName = "Date")]
    public DateTime OrderDate { get; set; }
    [Display(Name = "Total Price")]
    public double TotalPrice { get; set; }
    public virtual Customer Customer { get; set; }
    public virtual ICollection<OrderDetails> OrderDetails { get; set; }
  }
}

using MusicTime.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MusicTime.Web.Models
{
  public class CustomerOrder
  {
    public int Id { get; set; }
    public int UserId { get; set; }
    [Column(TypeName = "Date")]
    public DateTime OrderDate { get; set; }
    [Display(Name = "Total Price")]
    public double TotalPrice { get; set; }
    public virtual ApplicationUser Customer { get; set; }
    public virtual ICollection<OrderDetails> OrderDetails { get; set; }
  }
}

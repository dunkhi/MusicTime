using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTime.Domain
{
  public class EmailAddress
  {
    [Key]
    public int Id { get; set; }
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    public int? CustomerId { get; set; }

    //[UIHint("IsDefault")]
    public bool IsDefault { get; set; }
    public virtual ApplicationUser User { get; set; }
  }
}

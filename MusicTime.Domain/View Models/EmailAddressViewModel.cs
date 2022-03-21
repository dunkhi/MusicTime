using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTime.Domain.View_Models
{
  public class EmailAddressViewModel
  {
    public int? CustomerID { get; set; }

    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
  }
}

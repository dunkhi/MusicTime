using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTime.Domain.View_Models
{
  public class EmailAddressListViewModel
  {
    public int CustomerID { get; set; }

    public ICollection<EmailAddress> EmailAddresses { get; set; }
  }
}

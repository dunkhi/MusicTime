using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTime.Domain.View_Models
{
  public class PostalAddressListViewModel
  {
    [StringLength(38)]
    public int CustomerID { get; set; }

    public ICollection<PostalAddressViewModel> PostalAddresses { get; set; }
  }
}

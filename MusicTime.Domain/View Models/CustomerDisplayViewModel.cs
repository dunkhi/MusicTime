using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTime.Domain.View_Models
{
  public class CustomerDisplayViewModel
  {
    [Display(Name = "Customer Number")]
    public Guid CustomerID { get; set; }

    [Display(Name = "Customer Name")]
    public string CustomerName { get; set; }

    [Display(Name = "Country")]
    public string CountryName { get; set; }

    [Display(Name = "State / Province / Region")]
    public string RegionName { get; set; }
  }
}

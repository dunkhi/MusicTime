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
    public int Id { get; set; }

    [Display(Name = "Name")]
    public string CustomerName { get; set; }

    [Display(Name = "Username")]
    public string UserName { get; set; }

    [Display(Name = "Country")]
    public string CountryName { get; set; }

    [Display(Name = "State")]
    public string RegionName { get; set; }
  }
}

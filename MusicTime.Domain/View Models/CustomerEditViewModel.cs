using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MusicTime.Domain.View_Models
{
  public class CustomerEditViewModel
  {
    [Display(Name = "Customer Number")]
    [Key]
    public string CustomerID { get; set; }

    [Required]
    [Display(Name = "Customer Name")]
    [StringLength(75)]
    public string CustomerName { get; set; }

    [Required]
    [Display(Name = "Country")]
    public string SelectedCountryIso3 { get; set; }
    public IEnumerable<SelectListItem> Countries { get; set; }

    [Required]
    [Display(Name = "State / Region")]
    public string SelectedRegionCode { get; set; }
    public IEnumerable<SelectListItem> Regions { get; set; }

  }
}

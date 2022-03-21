using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MusicTime.Domain.View_Models
{
  public class PostalAddressEditViewModel
  {
    [Key]
    public int PostalAddressID { get; set; }

    public int? CustomerID { get; set; }

    [Display(Name = "Address Line 1")]
    [StringLength(100)]
    public string StreetAddress1 { get; set; }

    [Display(Name = "Address Line 2")]
    [StringLength(100)]
    public string StreetAddress2 { get; set; }

    [StringLength(50)]
    public string City { get; set; }

    [Display(Name = "Zip")]
    [StringLength(10)]
    public string PostalCode { get; set; }

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

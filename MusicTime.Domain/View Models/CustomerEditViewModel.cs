using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MusicTime.Domain.View_Models
{
  public class CustomerEditViewModel
  {
    [Key]
    public int Id { get; set; }

    [Display(Name = "First Name")]
    [StringLength(75)]
    public string FirstName { get; set; }

    [Display(Name = "Last Name")]
    public string LastName { get; set; }

    public string UserName { get; set; }

    [Required]
    [Display(Name = "Country")]
    public string SelectedCountryIso3 { get; set; }
    public IEnumerable<SelectListItem> Countries { get; set; }

    [Required]
    [Display(Name = "State / Region")]
    public string SelectedRegionCode { get; set; }
    public IEnumerable<SelectListItem> Regions { get; set; }

    public int PostalAddressId { get; set; }
    
    public virtual PostalAddress DefaultPostalAddress { get; set; }

    public IEnumerable<EmailAddress> EmailAddresses { get; set; }
    public IEnumerable<PostalAddress> PostalAddresses { get; set; }

  }
}

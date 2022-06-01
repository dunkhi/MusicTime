using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MusicTime.Domain.View_Models
{
  public class UserIndexViewModel
  {
    public string Id { get; set; }
    [Display(Name = "Name")]
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    public string Roles { get; set; }
  }

  public class UserCreateViewModel
  {
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }

    [Required]
    [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string Password { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    public string ConfirmPassword { get; set; }

    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }

    [Required]
    [Display(Name = "Country")]
    public string SelectedCountryIso3 { get; set; }
    public IEnumerable<SelectListItem> Countries { get; set; }

    [Required]
    [Display(Name = "State / Region")]
    public string SelectedRegionCode { get; set; }
    public IEnumerable<SelectListItem> Regions { get; set; }

    public string[] selectedRoles { get; set; }
    public IEnumerable<SelectListItem> Roles { get; set; }
    public SelectList RolesSelectList { get; set; }
    public IEnumerable<IdentityRole> IdentityRoles { get; set; }
  }

  public class UserEditViewModel
  {
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }

    //[Required]
    //[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
    //[DataType(DataType.Password)]
    //[Display(Name = "Password")]
    //public string Password { get; set; }

    //[DataType(DataType.Password)]
    //[Display(Name = "Confirm password")]
    //public string ConfirmPassword { get; set; }

    //public string Address { get; set; }
    //public string City { get; set; }
    //public string State { get; set; }

    [Display(Name = "Country")]
    public string SelectedCountryIso3 { get; set; }
    public IEnumerable<SelectListItem> Countries { get; set; }

    [Display(Name = "State / Region")]
    public string SelectedRegionCode { get; set; }
    public IEnumerable<SelectListItem> Regions { get; set; }

    public string[] selectedRoles { get; set; }
    public IEnumerable<SelectListItem> Roles { get; set; }
    public SelectList RolesSelectList { get; set; }
    public IEnumerable<IdentityRole> IdentityRoles { get; set; }
  }
}

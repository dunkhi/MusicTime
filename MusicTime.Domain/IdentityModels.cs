using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MusicTime.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MusicTime.Domain
{
  public class ApplicationUser : IdentityUser
  {
    public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
    {
      // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
      var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
      // Add custom user claims here
      return userIdentity;
    }

    [Display(Name = "First")]
    public string FirstName { get; set; }

    [Display(Name = "Last")]
    public string LastName { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string FullName { get; set; }

    public virtual ICollection<CustomerOrder> CustomerOrders { get; set; }

    [MaxLength(3)]
    public string CountryIso3 { get; set; }

    [MaxLength(3)]
    public string RegionCode { get; set; }
    public virtual Country Country { get; set; }
    public virtual Region Region { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }

    [Display(Name = "Postal Code")]
    public string PostalCode { get; set; }

    public string DisplayAddress
    {
      get
      {
        string dspAddress =
            string.IsNullOrWhiteSpace(this.Address) ? "" : this.Address;
        string dspCity =
            string.IsNullOrWhiteSpace(this.City) ? "" : this.City;
        string dspState =
            string.IsNullOrWhiteSpace(this.State) ? "" : this.State;
        string dspPostalCode =
            string.IsNullOrWhiteSpace(this.PostalCode) ? "" : this.PostalCode;

        return string
            .Format("{0} {1} {2} {3}", dspAddress, dspCity, dspState, dspPostalCode);
      }
    }
  }

  
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTime.Domain
{
  public class Customer
  {
    public int Id { get; set; }

    [Display(Name = "First")]
    public string FirstName { get; set; }

    [Display(Name = "Last")]
    public string LastName { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string FullName { get; set; }
    //public string FullName
    //{
    //  get { return string.Format("{0} {1}", FirstName, LastName); }
    //}

    [Display(Name = "Username")]
    public string UserName { get; set; }

    [MaxLength(3)]
    public string CountryIso3 { get; set; }

    [MaxLength(3)]
    public string RegionCode { get; set; }

    public virtual Country Country { get; set; }

    public virtual Region Region { get; set; }

    public virtual ICollection<EmailAddress> EmailAddresses { get; set; }
    public virtual ICollection<PostalAddress> PostalAddresses { get; set; }
    public virtual ICollection<CustomerOrder2> CustomerOrders { get; set; }
  }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTime.Domain
{
  public class PostalAddress
  {
    [Key]
    public int Id { get; set; }

    public int? CustomerID { get; set; }
    public bool IsDefault { get; set; }

    [MaxLength(3)]
    [Display(Name = "Country")]
    public string Iso3 { get; set; }

    [MaxLength(100)]
    [Display(Name = "Street 1")]
    public string StreetAddress1 { get; set; }

    [MaxLength(100)]
    [Display(Name = "Street 2")]
    public string StreetAddress2 { get; set; }

    [MaxLength(50)]
    public string City { get; set; }

    [MaxLength(3)]
    [Display(Name = "Region")]
    public string RegionCode { get; set; }

    [MaxLength(10)]
    [Display(Name = "Zip")]
    public string PostalCode { get; set; }

    public virtual Customer Customer { get; set; }

    public virtual Country Country { get; set; }

    public virtual Region Region { get; set; }
  }
}

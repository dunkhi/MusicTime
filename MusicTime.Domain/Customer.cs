using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTime.Domain
{
  public class Customer
  {
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }

    [MaxLength(3)]
    public string CountryIso3 { get; set; }

    [MaxLength(3)]
    public string RegionCode { get; set; }

    public virtual Country Country { get; set; }

    public virtual Region Region { get; set; }
  }
}

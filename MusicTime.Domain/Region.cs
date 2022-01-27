using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTime.Domain
{
  public class Region
  {
    [Key]
    [MaxLength(3)]
    public string RegionCode { get; set; }

    [Required]
    [MaxLength(3)]
    public string Iso3 { get; set; }

    [Required]
    public string RegionNameEnglish { get; set; }

    public virtual Country Country { get; set; }
  }
}

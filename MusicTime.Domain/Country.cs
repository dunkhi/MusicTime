using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTime.Domain
{
  public class Country
  {
    [Key]
    [MaxLength(3)]
    public string Iso3 { get; set; }

    [Required]
    [MaxLength(50)]
    [Display(Name = "Country")]
    public string CountryNameEnglish { get; set; }

    public virtual IEnumerable<Region> Regions { get; set; }
  }
}

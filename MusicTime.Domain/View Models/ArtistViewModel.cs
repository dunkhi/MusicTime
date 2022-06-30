using MusicTime.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MusicTime.Domain.View_Models
{

  public class ArtistEditViewModel
  {
    public int Id { get; set; }
    [Required]
    [StringLength(60)]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }

    [Required]
    [StringLength(60)]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }

    public Instrument Instrument { get; set; }
    public int Age { get; set; }

    [Display(Name = "Artist Biography")]
    public string ArtistBio { get; set; }

    public IEnumerable<SelectListItem> Bands { get; set; }
    public int BandId { get; set; }
    public int[] BandsIds { get; set; }

    public virtual Band Band { get; set; }
  }
}

using MusicTime.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTime.Domain
{
  public class Artist
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

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public string FullName { get; set; }
    public Instrument Instrument { get; set; }
    public int Age { get; set; }

    [Display(Name = "Artist Biography")]
    public string ArtistBio { get; set; }
    public int BandId { get; set; }

    public virtual Band Band { get; set; }
  }
}

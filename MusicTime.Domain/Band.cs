using MusicTime.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTime.Domain
{
  public class Band
  {
    [Required]
    public int id { get; set; }

    [Required]
    [StringLength(60)]
    public string Name { get; set; }
    [Display(Name = "Band Biography")]
    public string BandBio { get; set; }
    public virtual string Logo { get; set; }
    public virtual string Photo { get; set; }
    [Required]
    public virtual GenreEnum Genre { get; set; }
    public virtual ICollection<Artist> Artists { get; set; }
    public virtual ICollection<Album> Albums { get; set; }
    public virtual ICollection<Concert> Concerts { get; set; }
  }
}

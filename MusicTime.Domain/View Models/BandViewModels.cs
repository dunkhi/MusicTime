using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTime.Domain.View_Models
{
  public class BandAlbumViewModel
  {
    public int Id { get; set; }
    public virtual ICollection<Album> Albums { get; set; }
  }

  public class BandConcertViewModel
  {
    public int Id { get; set; }
    public virtual ICollection<Concert> Concerts { get; set; }
  }
}

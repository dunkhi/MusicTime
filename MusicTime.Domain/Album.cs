using MusicTime.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTime.Domain
{
  public class Album
  {
    public virtual int Id { get; set; }
    public virtual int BandId { get; set; }
    public virtual string Title { get; set; }
    public virtual decimal Price { get; set; }
    public virtual int Year { get; set; }
    public virtual GenreEnum Genre { get; set; }
    public virtual Band Band { get; set; }
  }
}

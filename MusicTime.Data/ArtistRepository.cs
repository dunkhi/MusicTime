using MusicTime.Domain;
using MusicTime.Domain.View_Models;
using MusicTime.Web.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MusicTime.Data
{
  public class ArtistRepository
  {
    ApplicationDbContext _context;

    public ArtistRepository(ApplicationDbContext context)
    {
      _context = context;
    }

    public ArtistEditViewModel GetArtistEvm(int? id)
    {
      var artist = _context.Artists.Find(id);
      var bands = _context.Bands.ToList();
      var vm = new ArtistEditViewModel
      {
        FirstName = artist.FirstName,
        LastName = artist.LastName,
        Age = artist.Age,
        ArtistBio = artist.ArtistBio,
        Instrument = artist.Instrument,
        Bands = bands.ToSelectListItem(b => b.Name, b => b.Name, b => b.id.ToString())
      };
      return vm;
    }

  }
}

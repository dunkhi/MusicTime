using MusicTime.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTime.Data
{
  public class BandRepository
  {
    ApplicationDbContext _context;

    public BandRepository(ApplicationDbContext context)
    {
      _context = context;
    }

    public List<Band> GetBands()
    {
      return _context.Bands.ToList();
    }

    public Band FindBand(int? id)
    {
      var band = _context.Bands.AsNoTracking()
                 .FirstOrDefault(b => b.id == id);
      return band;
    }

    public IEnumerable<Band> SearchBand(string searchTerm)
    {
      var band = _context.Bands
                         .Where(b => b.Name.Contains(searchTerm))
                         .Take(5);
      return band;
    }
    public void CreateBand(Band band)
    {
      _context.Bands.Add(band);
      _context.SaveChanges();
    }
  }
}

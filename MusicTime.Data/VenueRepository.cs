using MusicTime.Domain;
using MusicTime.Domain.View_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTime.Data
{
  public class VenueRepository
  {
    private readonly ApplicationDbContext _context;
    public VenueRepository(ApplicationDbContext context)
    {
      _context = context;
    }

    public List<VenueConcertViewModel> GetVenueConcertCount()
    {
      var venues = _context.Venues
                           .Select(v => new VenueConcertViewModel
                           {
                             Id = v.Id,
                             Name = v.Name,
                             City = v.City,
                             State = v.State,
                             Capacity = v.Capacity,
                             Type = v.Type,
                             ConcertCount = v.Concerts.Count()
                           }).ToList();
      return venues;
    }
  }
}

using MusicTime.Domain.View_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTime.Data
{
  public class TicketRepository
  {
    private MusicTimeContext _context;
    public TicketRepository(MusicTimeContext context)
    {
      _context = context;
    }

    public List<ProductTicketViewModel> GetConcertTickets(int concertId)
    {
      var tickets = _context.Tickets
                            .Where(t => t.ConcertId == concertId)
                            .Select(t => new ProductTicketViewModel
                            {
                              TicketId = t.Id,
                              ProductId = t.ProductId,
                              Name = t.Product.Name,
                              Description = t.Product.Description,
                              Seat = t.Seat,
                              Area = t.Area,
                              TicketType = t.TicketType,
                              Price = t.Price
                            }).ToList();
      return tickets;
    }
  }
}

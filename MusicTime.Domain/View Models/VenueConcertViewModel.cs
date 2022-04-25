using MusicTime.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTime.Domain.View_Models
{
  public class VenueConcertViewModel
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public int Capacity { get; set; }
    public VenueType Type { get; set; }
    [Display(Name = "Concerts")]
    public int ConcertCount { get; set; }
  }
}

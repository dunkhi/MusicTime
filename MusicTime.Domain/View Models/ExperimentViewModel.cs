using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MusicTime.Domain.View_Models
{
  public class ExperimentViewModel
  {
    public IEnumerable<SelectListItem> Bands { get; set; }
    public int[] BandIds { get; set; }
  }
}

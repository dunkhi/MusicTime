using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MusicTime.Data
{
  public class CountriesRepository
  {
    ApplicationDbContext _context;
    public CountriesRepository(ApplicationDbContext context)
    {
      _context = context;
    }
    public IEnumerable<SelectListItem> GetCountries()
    {
      List<SelectListItem> countries = _context.Countries
                                               .OrderBy(n => n.CountryNameEnglish)
                                               .Select(n =>
                                                  new SelectListItem
                                                  {
                                                    Value = n.Iso3.ToString(),
                                                    Text = n.CountryNameEnglish
                                                  }).ToList();
      var countrytip = new SelectListItem()
      {
        Value = null,
        Text = "--- select country ---"
      };
      countries.Insert(0, countrytip);
      return new SelectList(countries, "Value", "Text");

    }
  }
}


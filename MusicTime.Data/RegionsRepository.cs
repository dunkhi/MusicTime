using MusicTime.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MusicTime.Data
{
  public class RegionsRepository
  {
    ApplicationDbContext _context;

    public RegionsRepository(ApplicationDbContext context)
    {
      _context = context;
    }

    public IEnumerable<SelectListItem> GetRegions()
    {
      List<SelectListItem> regions = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Value = null,
                    Text = " "
                }
            };
      return regions;
    }

    public IEnumerable<SelectListItem> GetRegions(string isoCode)
    {
      if (!String.IsNullOrWhiteSpace(isoCode))
      {
        var regions = _context.Regions.AsNoTracking()
                      .OrderBy(r => r.RegionNameEnglish)
                      .Where(r => r.Iso3 == isoCode)
                      .Select(r =>
                        new SelectListItem
                        {
                          Value = r.RegionCode,
                          Text = r.RegionNameEnglish
                        }).ToList();

        return new SelectList(regions, "Value", "Text");
      }
      return null;
    }

    public IEnumerable<SelectListItem> GetRegionsEdit(Customer customer)
    {
      var customerRegion = _context.Regions.AsNoTracking()
                           .OrderBy(r => r.RegionNameEnglish)
                           .Where(r => r.Iso3 == customer.CountryIso3)
                           .Select(r =>
                              new SelectListItem
                              {
                                Value = r.RegionCode,
                                Text = r.RegionNameEnglish
                              }).ToList();
      return new SelectList(customerRegion, "Value", "Text", customer.RegionCode);
    }
  }
}

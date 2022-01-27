using MusicTime.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using MusicTime.Domain.View_Models;

namespace MusicTime.Data
{
  public class CustomerRepository
  {
    MusicTimeContext _context;
    public CustomerRepository(MusicTimeContext context)
    {
      _context = context;
    }

    public List<Customer> GetCustomers()
    {
      List<Customer> customers = new List<Customer>();
      customers = _context.Customers
                          .Include(x => x.Country)
                          .Include(x => x.Region)
                          .ToList();
      return customers;
    }

    public CustomerEditViewModel CreateCustomer()
    {
      var cRepo = new CountriesRepository(new MusicTimeContext());
      var rRepo = new RegionsRepository(new MusicTimeContext());
      var customer = new CustomerEditViewModel()
      {
        CustomerID = Guid.NewGuid().ToString(),
        Countries = cRepo.GetCountries(),
        Regions = rRepo.GetRegions()
      };
      return customer;
    }

    public bool SaveCustomer(CustomerEditViewModel customeredit)
    {
      if (customeredit != null)
      {
        using (var context = new MusicTimeContext())
        {
            var customer = new Customer()
            {
              FirstName = customeredit.CustomerName,
              CountryIso3 = customeredit.SelectedCountryIso3,
              RegionCode = customeredit.SelectedRegionCode
            };
            customer.Country = context.Countries.Find(customeredit.SelectedCountryIso3);
            customer.Region = context.Regions.Find(customeredit.SelectedRegionCode);

            context.Customers.Add(customer);
            context.SaveChanges();
            return true;
        }
      }
      // Return false if customeredit == null or CustomerID is not a guid
      return false;
    }
  }
}

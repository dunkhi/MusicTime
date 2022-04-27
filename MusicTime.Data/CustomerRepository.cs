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
    ApplicationDbContext _context;
    private CountriesRepository cRepo;
    private RegionsRepository rRepo;
    private AddressRepository aRepo;
    public CustomerRepository(ApplicationDbContext context)
    {
      _context = context;
      cRepo = new CountriesRepository(new ApplicationDbContext());
      rRepo = new RegionsRepository(new ApplicationDbContext());
      aRepo = new AddressRepository(new ApplicationDbContext());
    }

    public List<CustomerDisplayViewModel> GetCustomers()
    {
      List<Customer> customers = new List<Customer>();
      customers = _context.Customers
                          .Include(x => x.Country)
                          .Include(x => x.Region)
                          .ToList();
      if (customers != null)
      {
        var customerDisplayList = new List<CustomerDisplayViewModel>();
        foreach (var c in customers)
        {
          var customerDisplay = new CustomerDisplayViewModel()
          {
            Id = c.Id,
            CustomerName = c.FirstName,
            UserName = c.UserName,
            CountryName = c.Country.CountryNameEnglish,
            RegionName = c.Region.RegionNameEnglish
          };
          customerDisplayList.Add(customerDisplay);
        }
        return customerDisplayList;
      }
      return null;
    }

    public Customer GetCustomers(int? id)
    {
      var customer = _context.Customers.Find(id);
      return customer;
    }

    public CustomerEditViewModel CreateCustomer()
    {
      var customer = new CustomerEditViewModel()
      {
        Countries = cRepo.GetCountries(),
        Regions = rRepo.GetRegions()
      };
      return customer;
    }

    public bool SaveCustomer(CustomerEditViewModel customeredit)
    {
      if (customeredit != null)
      {
        var customer = new Customer()
        {
          FirstName = customeredit.FirstName,
          LastName = customeredit.LastName,
          UserName = customeredit.UserName,
          CountryIso3 = customeredit.SelectedCountryIso3,
          RegionCode = customeredit.SelectedRegionCode
        };
        customer.Country = _context.Countries.Find(customeredit.SelectedCountryIso3);
        customer.Region = _context.Regions.Find(customeredit.SelectedRegionCode);

        _context.Customers.Add(customer);
        _context.SaveChanges();
        return true;
      }
      // Return false if customeredit == null or CustomerID is not a guid
      return false;
    }

    public Customer Find(int? id)
    {
      var customer = _context.Customers.Find(id);
      return customer;
    }

    public CustomerEditViewModel GetCustomer(int? id)
    {
      var customer = _context.Customers.Where(c => c.Id == id).SingleOrDefault();

      var customerEVM = new CustomerEditViewModel
      {
        Id = customer.Id,
        FirstName = customer.FirstName,
        LastName = customer.LastName,
        UserName = customer.UserName,
        SelectedCountryIso3 = customer.CountryIso3,
        SelectedRegionCode = customer.RegionCode,
        EmailAddresses = customer.EmailAddresses,
        PostalAddresses = customer.PostalAddresses
      };
      customerEVM.Countries = cRepo.GetCountries();
      customerEVM.Regions = rRepo.GetRegions();
      return customerEVM;
    }

    public bool SaveEmailAddress(EmailAddressViewModel model)
    {
      if (model != null)
      {
        var customer = _context.Customers.Where(c => c.Id == model.CustomerID);

        var emailAddress = new EmailAddress()
        {
          CustomerId = model.CustomerID,
          Email = model.Email
        };
        _context.EmailAddresses.Add(emailAddress);
        _context.SaveChanges();
        return true;
      }
      return false;
    }

    public CustomerEditViewModel GetCustomerEdit(int? id)
    {
      var customer = _context.Customers.Where(c => c.Id == id).SingleOrDefault();
      var customerEVM = new CustomerEditViewModel
      {
        Id = customer.Id,
        FirstName = customer.FirstName,
        LastName = customer.LastName,
        UserName = customer.UserName,
        SelectedCountryIso3 = customer.CountryIso3,
        SelectedRegionCode = customer.RegionCode,
        EmailAddresses = customer.EmailAddresses,
        PostalAddresses = customer.PostalAddresses,
        DefaultPostalAddress = aRepo.GetDefaultPostalAddress(customer.Id)
      };
      customerEVM.Countries = cRepo.GetCountries();
      customerEVM.Regions = rRepo.GetRegionsEdit(customer);
      return customerEVM;
    }

    public void SaveChanges(CustomerEditViewModel model)
    {
      var customer = _context.Customers.Where(c => c.Id == model.Id).SingleOrDefault();

      customer.FirstName = model.FirstName;
      customer.LastName = model.LastName;
      customer.UserName = model.UserName;
      customer.RegionCode = model.SelectedRegionCode;
      customer.CountryIso3 = model.SelectedCountryIso3;
      _context.SaveChanges();
    }
  }
}

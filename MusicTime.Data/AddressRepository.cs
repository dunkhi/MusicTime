using MusicTime.Domain;
using MusicTime.Domain.Enums;
using MusicTime.Domain.View_Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MusicTime.Data
{
  public class AddressRepository
  {
    MusicTimeContext _context;
    private RegionsRepository _regionsRepository;
    private CountriesRepository _countriesRepository;

    public AddressRepository(MusicTimeContext context)
    {
      _context = context;
      _regionsRepository = new RegionsRepository(new MusicTimeContext());
      _countriesRepository = new CountriesRepository(new MusicTimeContext());
    }

    public IEnumerable<SelectListItem> GetAddressTypes()
    {
      var addressTypes = _context.AddressTypes.AsNoTracking()
                                 .OrderBy(t => t.Addresstype)
                                 .Select(t => new SelectListItem
                                 {
                                   Value = t.Addresstype,
                                   Text = t.Addresstype
                                 }).ToList();

      var enumAddressTypes = Enum.GetValues(typeof(AddressTypeEnum))
                                  .Cast<AddressTypeEnum>();

      var items = from value in enumAddressTypes
                  select new SelectListItem
                  {
                    Value = value.ToString(),
                    Text = value.ToString()
                  };
      return new SelectList(items, "Value", "Text");
      //return new SelectList(addressTypes, "Value", "Text");
    }

    public PostalAddressEditViewModel CreatePostal(int? id)
    {
      var postal = new PostalAddressEditViewModel()
      {
        CustomerID = id,
        Regions = _regionsRepository.GetRegions(),
        Countries = _countriesRepository.GetCountries()
      };
      return postal;
    }
    public bool SaveEditPostalAddress(PostalAddressEditViewModel model)
    {
      if (model != null)
      {
        var postalAddress = _context.PostalAddresses.Where(c => c.Id == model.PostalAddressID).FirstOrDefault();
        postalAddress.StreetAddress1 = model.StreetAddress1;
        postalAddress.StreetAddress2 = model.StreetAddress2;
        postalAddress.City = model.City;
        postalAddress.PostalCode = model.PostalCode;
        postalAddress.Iso3 = model.SelectedCountryIso3;
        postalAddress.RegionCode = model.SelectedRegionCode;
        postalAddress.Region = _context.Regions.Find(postalAddress.RegionCode);
        postalAddress.Country = _context.Countries.Find(postalAddress.Iso3);
        return true;
      }
      return false;
    }

    public bool SavePostalAddress(PostalAddressEditViewModel model)
    {
      var postalCount = _context.PostalAddresses.Where(c => c.CustomerID == model.CustomerID).Count();
      if (model != null)
      {
        var customer = _context.Customers.Where(c => c.Id == model.CustomerID);
        var postalAddress = new PostalAddress()
        {
          CustomerID = model.CustomerID,
          Iso3 = model.SelectedCountryIso3,
          StreetAddress1 = model.StreetAddress1,
          StreetAddress2 = model.StreetAddress2,
          PostalCode = model.PostalCode,
          RegionCode = model.SelectedRegionCode,
          City = model.City
        };
        postalAddress.Region = _context.Regions.Find(postalAddress.RegionCode);
        postalAddress.Country = _context.Countries.Find(postalAddress.Iso3);

        if (postalCount == 0)
        {
          postalAddress.IsDefault = true;
        }

        _context.PostalAddresses.Add(postalAddress);
        _context.SaveChanges();
        return true;
      }
      return false;
    }

    public bool SetDefaultEmail(int? id, int? customerId)
    {
      var email = _context.EmailAddresses.Where(e => e.Id == id).SingleOrDefault();

      var cEmails = _context.EmailAddresses.Where(c => c.CustomerId == customerId).ToList();

      foreach (var cmail in cEmails)
      {
        if (cmail.IsDefault == true && cmail.Id != id)
        {
          cmail.IsDefault = false;
          _context.SaveChanges();
        }
      }

      if (email != null)
      {
        email.IsDefault = !email.IsDefault;
        _context.SaveChanges();
        return true;
      }
      return false;
    }

    public void DeleteEmail(int? emailId)
    {
      var email = _context.EmailAddresses.Find(emailId);
      _context.EmailAddresses.Remove(email);
      _context.SaveChanges();
    }

    public bool SetDefaultPostal(int? id, int? customerId)
    {
      var postalAddress = _context.PostalAddresses.Where(p => p.Id == id).FirstOrDefault();
      var postalAddressList = _context.PostalAddresses.Where(p => p.CustomerID == customerId).ToList();

      foreach (var postal in postalAddressList)
      {
        if (postal.IsDefault == true && postal.Id != id)
        {
          postal.IsDefault = false;
          _context.SaveChanges();
        }
        
      }

      if (postalAddress != null)
      {
        postalAddress.IsDefault = !postalAddress.IsDefault;
        _context.SaveChanges();
        return true;
      }
      return false;
    }

    public EmailAddress CreateEmail(int? id)
    {
      var email = new EmailAddress
      {
        CustomerId = id
      };
      return email;
    }

    public bool SaveEmailAddress(EmailAddress model)
    {
      if (model != null)
      {
        var customer = _context.Customers.Where(c => c.Id == model.CustomerId);
        var customerEmailCount = _context.EmailAddresses.Where(c => c.CustomerId == model.CustomerId).Count();

        var emailAddress = new EmailAddress()
        {
          CustomerId = model.CustomerId,
          Email = model.Email,
          IsDefault = model.IsDefault
        };

        if (customerEmailCount == 0) emailAddress.IsDefault = true;
        // set all customer email addresses default to false
        var customerId = new SqlParameter("@id", model.CustomerId);

        if (model.IsDefault == true)
        {
          _context.Database.ExecuteSqlCommand("UPDATE dbo.EmailAddresses SET IsDefault = 0 WHERE CustomerId = @id", customerId);
        }
        
        _context.EmailAddresses.Add(emailAddress);
        _context.SaveChanges();
        return true;
      }
      return false;
    }

    public EmailAddressListViewModel GetEmailAddressList(int? id)
    {
      var emailAddresses = _context.EmailAddresses.AsNoTracking()
                                    .Where(c => c.CustomerId == id)
                                    .OrderBy(c => c.Email);
      var emailAddressLVM = new EmailAddressListViewModel();

      foreach (var email in emailAddresses)
      {
        emailAddressLVM.EmailAddresses.Add(email);
      }
      return emailAddressLVM;
    }

    public PostalAddress GetDefaultPostalAddress(int? id)
    {
      var customer = _context.Customers.Where(c => c.Id == id);
      var defaultPostal = _context.PostalAddresses.Where(p => p.CustomerID == id && p.IsDefault == true)
                                           .FirstOrDefault();
      return defaultPostal;
    }

    public PostalAddressEditViewModel GetPostalAddress(int? id, int? customerId)
    {
      var postal = _context.PostalAddresses.Where(p => p.Id == id).FirstOrDefault();
      var customer = _context.Customers.Where(c => c.Id == customerId).FirstOrDefault();
      var postalEVM = new PostalAddressEditViewModel()
      {
        PostalAddressID = postal.Id,
        CustomerID = postal.CustomerID,
        City = postal.City,
        StreetAddress1 = postal.StreetAddress1,
        StreetAddress2 = postal.StreetAddress2,
        PostalCode = postal.PostalCode,
        SelectedCountryIso3 = postal.Iso3,
        SelectedRegionCode = postal.RegionCode,
        Regions = _regionsRepository.GetRegionsEdit(customer),
        Countries = _countriesRepository.GetCountries()
      };
      return postalEVM;
    }
  }
}

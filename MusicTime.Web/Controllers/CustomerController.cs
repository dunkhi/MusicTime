using MusicTime.Data;
using MusicTime.Domain;
using MusicTime.Domain.Enums;
using MusicTime.Domain.View_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicTime.Web.Controllers
{
  public class CustomerController : Controller
  {
    private CustomerRepository _customerRepository;
    private RegionsRepository _regionsRepository;
    private AddressRepository _addressRepository;
    private CountriesRepository _countriesRepository;
    private ApplicationDbContext _db = new ApplicationDbContext();
    public CustomerController()
    {
      _customerRepository = new CustomerRepository(new ApplicationDbContext());
      _regionsRepository = new RegionsRepository(new ApplicationDbContext());
      _addressRepository = new AddressRepository(new ApplicationDbContext());
      _countriesRepository = new CountriesRepository(new ApplicationDbContext());
    }
    // GET: Customer
    public ActionResult Index()
    {
      return View(_customerRepository.GetCustomers());
    }


    public JsonResult ReturnToAjaxParameter(string id, string name)
    {
      var tempId = $"Hello employee {id}";
      var tempName = $"your name is {name}";
      return Json(new { id = tempId, name = tempName }, JsonRequestBehavior.AllowGet);
    }

    [HttpGet]
    public ActionResult GetRegions(string countryCode)
    {
      var code = countryCode;
      if (!string.IsNullOrWhiteSpace(countryCode))
      {
        IEnumerable<SelectListItem> regions = _regionsRepository.GetRegions(countryCode);
        return Json(regions, JsonRequestBehavior.AllowGet);
      }
      return Json(new { value = countryCode, text = "goodbye" }, JsonRequestBehavior.AllowGet);
    }

    // GET: Customer/Create
    public ActionResult Create()
    {
      var customer = _customerRepository.CreateCustomer();
      return View(customer);
    }



    // POST: Customer/Create
    [HttpPost]
    public ActionResult Create([Bind(Include = "Id, FirstName, LastName, Email, Username, SelectedCountryIso3, SelectedRegionCode")] CustomerEditViewModel model)
    {
      try
      {
        if (ModelState.IsValid)
        {
          bool saved = _customerRepository.SaveCustomer(model);
          if (saved)
          {
            return RedirectToAction("Index");
          }
        }
        throw new ApplicationException("Invalid model");
      }
      catch (ApplicationException ex)
      {
        throw ex;
      }
    }

    public ActionResult Details(int? id)
    {
      if (id == null)
      {
        return View("Error");
      }
      else
      {
        return View(_customerRepository.Find(id));
      }
    }

    public ActionResult SetDefaultEmail(int? id, int? customerId)
    {
      var customer = _customerRepository.GetCustomer(customerId);
      if (_addressRepository.SetDefaultEmail(id, customerId))
      {
        return RedirectToAction("EditCustomerEmailPartial", customer);
      }
      return View("Error");
    }

    [HttpGet]
    public ActionResult EditCustomerEmailPartial(int? id)
    {
      return View(_customerRepository.GetCustomerEdit(id));
    }

    [HttpPost]
    public ActionResult EditCustomerEmailPartial([Bind(Include = "Id, FirstName, LastName, UserName, PostalCode, SelectedCountryIso3, SelectedRegionCode")] CustomerEditViewModel model)
    {
      if (ModelState.IsValid)
      {
        _customerRepository.SaveChanges(model);
        return RedirectToAction("Index");
      }
      return View(model);
    }

    public ActionResult CreateEmailAddress(int? id)
    {
      var model = _addressRepository.CreateEmail(id);
      return View(model);
    }

    [HttpPost]
    public ActionResult CreateEmailAddress(EmailAddress model)
    {
      if (ModelState.IsValid)
      {
        if (_addressRepository.SaveEmailAddress(model))
        {
          return RedirectToAction("Index");
        }
      }
      return View("Error");
    }

    public ActionResult DeleteEmail(int? emailId)
    {
      _addressRepository.DeleteEmail(emailId);
      return RedirectToAction("Index");
    }

    public ActionResult CreatePostalAddress(int? id)
    {
      var model = _addressRepository.CreatePostal(id);
      return View(model);
    }

    [HttpPost]
    public ActionResult CreatePostalAddress(PostalAddressEditViewModel model)
    {
      if (ModelState.IsValid)
      {
        if (_addressRepository.SavePostalAddress(model))
        {
          return RedirectToAction("EditCustomerEmailPartial", new { id = model.CustomerID });
        }
      }
      return View("Error");
    }

    [HttpGet]
    public ActionResult ViewPostalAddresses(int? id)
    {
      return View(_customerRepository.GetCustomerEdit(id));
    }

    public ActionResult SetDefaultPostal(int? id, int? customerId)
    {
      var customer = _customerRepository.GetCustomer(customerId);
      if (_addressRepository.SetDefaultPostal(id, customerId))
      {
        return RedirectToAction("ViewPostalAddresses", new { id = customer.Id });
      }
      return View("Error");
    }

    public ActionResult EditPostalAddress(int? id, int? customerId)
    {
      // get edit postal address view model with region and iso3 code dropdowns
      var postal = _addressRepository.GetPostalAddress(id, customerId);
      return View(postal);
    }

    [HttpPost]
    public ActionResult EditPostalAddress([Bind(Include = "PostalAddressID, CustomerId, StreetAddress1, StreetAddress2, City, PostalCode, SelectedCountryIso3, SelectedRegionCode")] PostalAddressEditViewModel model)
    {
      if (ModelState.IsValid)
      {
        _addressRepository.SaveEditPostalAddress(model);
        return RedirectToAction("ViewPostalAddresses", new { id = model.CustomerID });
      }
      return View("Error");
    }

    public ActionResult Edit(int? id)
    {
      return View(id);
    }

    [ChildActionOnly]
    public ActionResult EditCustomerPartial(int? id)
    {
      var model = _customerRepository.GetCustomer(id);
      return View(model);
    }

    [ChildActionOnly]
    public ActionResult AddressTypePartial(int? id)
    {
      if (id != null)
      {
        var model = new AddressTypeViewModel
        {
          CustomerID = id,
          AddressTypes = _addressRepository.GetAddressTypes()
        };
        return PartialView("AddressTypePartial", model);
      }
      return View("Error");
    }

    [HttpPost]
    public ActionResult AddressTypePartial(AddressTypeViewModel model)
    {
      if (ModelState.IsValid)
      {
        switch (model.AddressType)
        {
          case AddressTypeEnum.Email:
            var emailAddressModel = new EmailAddressViewModel()
            {
              CustomerID = model.CustomerID,
            };
            return PartialView("CreateEmailAddressPartial", emailAddressModel);
          case AddressTypeEnum.Postal:
            var postalAddressModel = new PostalAddressEditViewModel()
            {
              CustomerID = model.CustomerID,
              Countries = _countriesRepository.GetCountries(),
              Regions = _regionsRepository.GetRegions()
            };
            return PartialView("CreatePostalAddressPartial", postalAddressModel);
        }
      }

      return View("Error");
    }

    [HttpPost]
    public ActionResult CreateEmailAddressPartial(EmailAddress model)
    {
      if (ModelState.IsValid)
      {
        var saved = _addressRepository.SaveEmailAddress(model);
        if (saved)
        {
          return RedirectToAction("EditCustomerEmailPartial", new { id = model.CustomerId });
        }
      }
      return View("Error");
    }

    [HttpPost]
    public ActionResult CreatePostalAddressPartial(PostalAddressEditViewModel model)
    {
      if (ModelState.IsValid)
      {
        var saved = _addressRepository.SavePostalAddress(model);

        if (saved)
        {
          return RedirectToAction("Edit", new { id = model.CustomerID });
        }
      }
      return View("Error");
    }

    public ActionResult SaveChanges([Bind(Include = "Id, FirstName, LastName, UserName, SelectedCountryIso3, SelectedRegionCode")]CustomerEditViewModel model)
    {
      _customerRepository.SaveChanges(model);
      return RedirectToAction("Edit", new { id = model.Id });
    }
  }
}

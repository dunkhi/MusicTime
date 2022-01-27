using MusicTime.Data;
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
    public CustomerController()
    {
      _customerRepository = new CustomerRepository(new MusicTimeContext());
      _regionsRepository = new RegionsRepository(new MusicTimeContext());
    }
    // GET: Customer
    public ActionResult Index()
    {
      return View(_customerRepository.GetCustomers());
    }

    [HttpGet]
    public ActionResult GetRegions(string isoCode)
    {
      if (!string.IsNullOrWhiteSpace(isoCode))
      {
        IEnumerable<SelectListItem> regions = _regionsRepository.GetRegions(isoCode);
        return Json(regions, JsonRequestBehavior.AllowGet);
      }
      return null;
    }

    // GET: Customer/Create
    public ActionResult Create()
    {
      var customer = _customerRepository.CreateCustomer();
      return View(customer);
    }

    // POST: Customer/Create
    [HttpPost]
    public ActionResult Create([Bind(Include = "Id, FirstName, SelectedCountryIso3, SelectedRegionCode")] CustomerEditViewModel model)
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
        // Handling model state errors is beyond the scope of the demo, so just throwing an ApplicationException when the ModelState is invalid
        // and rethrowing it in the catch block.
        throw new ApplicationException("Invalid model");
      }
      catch (ApplicationException ex)
      {
        throw ex;
      }
    }
  }
}

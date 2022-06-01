using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using MusicTime.Data;
using MusicTime.Domain;
using MusicTime.Domain.View_Models;
using MusicTime.Web.Extensions;
using MusicTime.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MusicTime.Web.Controllers
{
  public class UsersController : Controller
  {
    private RegionsRepository _regionsRepository;
    private CountriesRepository _countriesRepository;
    private UserRepository _userRepository;

    public UsersController()
    {
      _regionsRepository = new RegionsRepository(new ApplicationDbContext());
      _countriesRepository = new CountriesRepository(new ApplicationDbContext());
      _userRepository = new UserRepository(new ApplicationDbContext());
    }

    public UsersController(ApplicationUserManager userManager,
    ApplicationRoleManager roleManager)
    {
      UserManager = userManager;
      RoleManager = roleManager;
      
    }

    private ApplicationUserManager _userManager;
    public ApplicationUserManager UserManager
    {
      get
      {
        return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
      }
      set
      {
        _userManager = value;
      }
    }

    private ApplicationRoleManager _roleManager;
    public ApplicationRoleManager RoleManager
    {
      get
      {
        return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
      }
      private set
      {
        _roleManager = value;
      }
    }

    public ActionResult Index()
    {
      //InsertCountriesRegions();
      return View(_userRepository.GetUsers());
    }

    [HttpGet]
    public ActionResult Create()
    {
      var roles = RoleManager.Roles.ToList();
      var rolesList = roles.Select(r => new SelectListItem
      {
        Value = r.Name,
        Text = r.Name
      });

      var uvm = new UserCreateViewModel()
      {
        Countries = _countriesRepository.GetCountries(),
        Regions = _regionsRepository.GetRegions(),
        Roles = rolesList,
        RolesSelectList = new SelectList(RoleManager.Roles.ToList(), "Name", "Name")
      };

      return View(uvm);
    }

    [HttpPost]
    public async Task<ActionResult> Create(UserCreateViewModel model, string[] selectedRoles, string[] htmlSelectedRoles)
    {
      if (ModelState.IsValid)
      { 
        var user = new ApplicationUser
        {
          FirstName = model.FirstName,
          LastName = model.LastName,
          Email = model.Email,
          UserName = model.UserName,
          CountryIso3 = model.SelectedCountryIso3,
          RegionCode = model.SelectedRegionCode,
        };

        var userCreated = await UserManager.CreateAsync(user, model.Password);

        if (userCreated.Succeeded)
        {
          if (htmlSelectedRoles != null)
          {
            var userToRoles = await UserManager.AddToRolesAsync(user.Id, htmlSelectedRoles);
            if (!userToRoles.Succeeded)
            {
              ModelState.AddModelError("", userToRoles.Errors.First());
              return View();
            }
          }
          return RedirectToAction("Index");
        }
        else
        {
          ModelState.AddModelError("", userCreated.Errors.First());
          return View();
        }
      }
      return View();
    }

    [HttpGet]
    public async Task<ActionResult> Details(string id)
    {
      var user = await UserManager.FindByIdAsync(id);
      var userRoles = await RoleManager.Roles.ToListAsync();
      var roles = new List<IdentityRole>();
      foreach (var role in userRoles)
      {
        if (await UserManager.IsInRoleAsync(id, role.Name))
        {
          roles.Add(role);
        }
      }

      var vm = new UserEditViewModel()
      {
        FirstName = user.FirstName,
        LastName = user.LastName,
        IdentityRoles = roles
      };
      return View(vm);
    }

    [HttpGet]
    public async Task<ActionResult> Edit(string id)
    {
      
      var user = await UserManager.FindByIdAsync(id);
      var userRoles = await UserManager.GetRolesAsync(id);

      return View(new UserEditViewModel()
      {
        Id = user.Id,
        FirstName = user.FirstName,
        LastName = user.LastName,
        Email = user.Email,
        UserName = user.UserName,
        SelectedCountryIso3 = user.CountryIso3,
        SelectedRegionCode = user.RegionCode,
        Countries = _countriesRepository.GetCountries(),
        Regions = _regionsRepository.GetUserRegion(user),
        Roles = RoleManager.Roles.ToList().Select(r => new SelectListItem()
        {
          Selected = userRoles.Contains(r.Name),
          Text = r.Name,
          Value = r.Name
        })
        //Roles = RoleManager.Roles.ToSelectListItem(r => r.Name, r => r.Name, r => r.Name) help with generic contains
      });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit([Bind(Include = "Email, Id, FirstName, LastName, UserName, SelectedCountryIso3, SelectedRegionCode")] UserEditViewModel model, params string[] selectedRoles)
    {
      if (ModelState.IsValid)
      {
        var user = await UserManager.FindByIdAsync(model.Id);

        if (user == null)
        {
          return HttpNotFound();
        }

        user.FirstName = model.FirstName;
        user.LastName = model.LastName;
        user.Email = model.Email;
        user.UserName = model.UserName;
        user.CountryIso3 = model.SelectedCountryIso3;
        user.RegionCode = model.SelectedRegionCode;

        var userRoles = await UserManager.GetRolesAsync(user.Id);

        selectedRoles = selectedRoles ?? new string[] { };
        
        // add/remove newly selected user roles if any
        var result = await UserManager.AddToRolesAsync(user.Id, selectedRoles.Except(userRoles).ToArray<string>());
        result = await UserManager.RemoveFromRolesAsync(user.Id, userRoles.Except(selectedRoles).ToArray<string>());

        return RedirectToAction("Index");
      }

      ModelState.AddModelError("", "Something failed");
      return View();
    }


    [HttpGet]
    public async Task<ActionResult> Delete(string id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      var user = await UserManager.FindByIdAsync(id);
      if (user == null)
      {
        return HttpNotFound();
      }
      return View(user);
    }

    // 
    [HttpPost]
    [ActionName("Delete")]
    public async Task<ActionResult> DeleteConfirmed(string id)
    {
      if (ModelState.IsValid)
      {
        var user = await UserManager.FindByIdAsync(id);
        var userDeleted = await UserManager.DeleteAsync(user);
        if (!userDeleted.Succeeded)
        {
          ModelState.AddModelError("", userDeleted.Errors.First());
          return View();
        }
        return RedirectToAction("Index");
      }
      return View();
    }

    private static void InsertCountriesRegions()
    {
      var context = new ApplicationDbContext();
      var countries = new List<Country>
      {
        new Country {
                    Iso3 = "USA",
                    CountryNameEnglish = "United States of America"
                },
                new Country
                {
                    Iso3 = "CAN",
                    CountryNameEnglish = "Canada"
                },
                new Country
                {
                    Iso3 = "FRA",
                    CountryNameEnglish = "France"
                }
      };
      foreach (var c in countries)
      {
        context.Countries.Add(c);
      }
      context.SaveChanges();

      var regions = new List<Region>
            {
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "AL",
                    RegionNameEnglish = "Alabama"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "AK",
                    RegionNameEnglish = "Alaska"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "AZ",
                    RegionNameEnglish = "Arizona"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "AR",
                    RegionNameEnglish = "Arkansas"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "CA",
                    RegionNameEnglish = "California"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "CO",
                    RegionNameEnglish = "Colorado"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "CT",
                    RegionNameEnglish = "Connecticut"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "DC",
                    RegionNameEnglish = "District of Columbia"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "DE",
                    RegionNameEnglish = "Delaware"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "FL",
                    RegionNameEnglish = "Florida"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "GA",
                    RegionNameEnglish = "Georgia"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "HI",
                    RegionNameEnglish = "Hawaii"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "IA",
                    RegionNameEnglish = "Iowa"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "ID",
                    RegionNameEnglish = "Idaho"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "IL",
                    RegionNameEnglish = "Illinois"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "IN",
                    RegionNameEnglish = "Indiana"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "KS",
                    RegionNameEnglish = "Kansas"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "KY",
                    RegionNameEnglish = "Kentucky"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "LA",
                    RegionNameEnglish = "Louisiana"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "MD",
                    RegionNameEnglish = "Maryland"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "ME",
                    RegionNameEnglish = "Maine"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "MA",
                    RegionNameEnglish = "Massachsetts"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "MI",
                    RegionNameEnglish = "Michigan"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "MN",
                    RegionNameEnglish = "Minnesota"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "MS",
                    RegionNameEnglish = "Mississippi"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "MO",
                    RegionNameEnglish = "Missouri"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "MT",
                    RegionNameEnglish = "Montana"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "NE",
                    RegionNameEnglish = "Nebraska"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "NV",
                    RegionNameEnglish = "Nevada"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "NH",
                    RegionNameEnglish = "New Hampshire"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "NJ",
                    RegionNameEnglish = "New Jersey"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "NM",
                    RegionNameEnglish = "New Mexico"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "NY",
                    RegionNameEnglish = "New York"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "NC",
                    RegionNameEnglish = "North Carolina"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "ND",
                    RegionNameEnglish = "North Dakota"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "OH",
                    RegionNameEnglish = "Ohio"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "OK",
                    RegionNameEnglish = "Oklahoma"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "OR",
                    RegionNameEnglish = "Oregon"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "PA",
                    RegionNameEnglish = "Pennsylvania"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "RI",
                    RegionNameEnglish = "Rhode Island"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "SC",
                    RegionNameEnglish = "South Carolina"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "SD",
                    RegionNameEnglish = "South Dakota"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "TN",
                    RegionNameEnglish = "Tennessee"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "TX",
                    RegionNameEnglish = "Texas"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "UT",
                    RegionNameEnglish = "Utah"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "VT",
                    RegionNameEnglish = "Vermont"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "VA",
                    RegionNameEnglish = "Virginia"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "WA",
                    RegionNameEnglish = "Washington"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "WV",
                    RegionNameEnglish = "West Virginia"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "WI",
                    RegionNameEnglish = "Wisconsin"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "WY",
                    RegionNameEnglish = "Wyoming"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "AS",
                    RegionNameEnglish = "American Samoa"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "FM",
                    RegionNameEnglish = "Federated States of Micronesia"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "GU",
                    RegionNameEnglish = "Guam"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "MH",
                    RegionNameEnglish = "Marshall Islands"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "MP",
                    RegionNameEnglish = "Northern Mariana Islands"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "PR",
                    RegionNameEnglish = "Puerto Rico"
                },
                new Region
                {
                    Iso3 = "USA",
                    RegionCode = "VI",
                    RegionNameEnglish = "US Virgin Islands"
                },
                new Region
                {
                    Iso3 = "CAN",
                    RegionCode = "AB",
                    RegionNameEnglish = "Alberta"
                },
                new Region
                {
                    Iso3 = "CAN",
                    RegionCode = "BC",
                    RegionNameEnglish = "British Columbia"
                },
                new Region
                {
                    Iso3 = "CAN",
                    RegionCode = "MB",
                    RegionNameEnglish = "Manitoba"
                },
                new Region
                {
                    Iso3 = "CAN",
                    RegionCode = "NB",
                    RegionNameEnglish = "New Brunswick"
                },
                new Region
                {
                    Iso3 = "CAN",
                    RegionCode = "NF",
                    RegionNameEnglish = "Newfoundland"
                },
                new Region
                {
                    Iso3 = "CAN",
                    RegionCode = "NT",
                    RegionNameEnglish = "Northwest Territories"
                },
                new Region
                {
                    Iso3 = "CAN",
                    RegionCode = "NS",
                    RegionNameEnglish = "Nova Scotia"
                },
                new Region
                {
                    Iso3 = "CAN",
                    RegionCode = "NU",
                    RegionNameEnglish = "Nunavut"
                },
                new Region
                {
                    Iso3 = "CAN",
                    RegionCode = "ON",
                    RegionNameEnglish = "Ontario"
                },
                new Region
                {
                    Iso3 = "CAN",
                    RegionCode = "PE",
                    RegionNameEnglish = "Prince Edward Island"
                },
                new Region
                {
                    Iso3 = "CAN",
                    RegionCode = "QC",
                    RegionNameEnglish = "Québec"
                },
                new Region
                {
                    Iso3 = "CAN",
                    RegionCode = "SK",
                    RegionNameEnglish = "Saskatchewan"
                },
                new Region
                {
                    Iso3 = "CAN",
                    RegionCode = "YT",
                    RegionNameEnglish = "Yukon"
                }
            };
      foreach (var r in regions)
      {
        context.Regions.Add(r);
      }
      context.SaveChanges();
    }
  }


}

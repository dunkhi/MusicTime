using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using MusicTime.Data;
using MusicTime.Domain;
using MusicTime.Domain.View_Models;
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
      
      return View(_userRepository.GetUsers());
    }

    

    // GET: Users
    //public async Task<ActionResult> Index()
    //{
    //  return View(await UserManager.Users.ToListAsync());
    //}

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
        Roles = RoleManager.Roles.ToList().Select(x => new SelectListItem()
        {
          Selected = userRoles.Contains(x.Name),
          Text = x.Name,
          Value = x.Name
        })
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
  }
}

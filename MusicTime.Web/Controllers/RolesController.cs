using Microsoft.AspNet.Identity;
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
  public class RolesController : Controller
  {
    private ApplicationDbContext context = new ApplicationDbContext();
    private readonly RoleRepository roleRepository;
    public RolesController()
    {
      roleRepository = new RoleRepository(new ApplicationDbContext());
    }

    public RolesController(ApplicationUserManager userManager,
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


    //[HttpGet]
    ////[Authorize(Roles ="Admin")]
    //public ActionResult Index()
    //{
      
    //  var r = context.Roles.ToList();
    //  var theRoles = roleRepository.GetRoles();
    //  var roles = RoleManager.Roles.ToList();

    //  ViewBag.Message = CreateRoles().ToString();
    //  return View(theRoles);
    //}

    [HttpGet]
    public async Task<ActionResult> Index()
    {
      return View(await RoleManager.Roles.ToListAsync());
    }

    public bool CreateRoles()
    {
      var roleName = "Admin";
      if (!RoleManager.RoleExists(roleName))
      {
        var roleResult = RoleManager.Create(new IdentityRole(roleName));
        if (roleResult.Succeeded)
        {
          return true;
        }
      }
      return false;
    }

    public ActionResult Create()
    {
      return View(new RoleViewModel());
    }

    [HttpPost]
    public async Task<ActionResult> Create(RoleViewModel model)
    {
      if (ModelState.IsValid)
      {
        //await roleRepository.CreateRole(model.Name);
        if (!RoleManager.RoleExists(model.Name))
        {
          var roleResult = await RoleManager.CreateAsync(new IdentityRole(model.Name));
          if (roleResult.Succeeded)
          {
            return RedirectToAction("Index");
          }
        }
        ViewBag.Message = "Role Exists";
      }
      return View(model);
    }

    public async Task<ActionResult> Details(string id)
    {
      // create a list of users in this role
      // display in html for loop
      var role = RoleManager.FindById(id);
      var users = UserManager.Users.ToList();

      var usersInRoleList = new List<ApplicationUser>();
      foreach (var user in users)
      {
        if (await UserManager.IsInRoleAsync(user.Id, role.Name))
        {
          usersInRoleList.Add(user);
        }
      }

      var vm = new RoleDetailViewModel()
      {
        Id = role.Id,
        Role = role,
        Users = usersInRoleList
      };
      return View(vm);
    }

    [HttpGet]
    public async Task<ActionResult> Edit(string id)
    {
      var role = RoleManager.FindById(id);
      var users = UserManager.Users.ToList();
      var usersInRoleList = new List<ApplicationUser>();

      foreach (var user in users)
      {
        if (await UserManager.IsInRoleAsync(user.Id, role.Name))
        {
          usersInRoleList.Add(user);
        }
      }
      var vm = new RoleEditViewModel()
      {
        Id = role.Id,
        Name = role.Name,
        Role = role,
        Users = usersInRoleList
      };
      return View(vm);
    }

    [HttpPost]
    public async Task<ActionResult> Edit([Bind(Include = "Id, Name")] RoleEditViewModel model, string[] usersToRemove)
    {
      var users = usersToRemove;

      foreach (var user in users)
      {
        var result = await UserManager.RemoveFromRoleAsync(user, model.Name);
      }

      return RedirectToAction("Index");
    }
    //  //
    //  // GET: /Roles/Details/5
    //  [HttpGet]
    //  public async Task<ActionResult> Details(string id)
    //  {
    //    if (id == null)
    //    {
    //      return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //    }
    //    var role = await RoleManager.FindByIdAsync(id);
    //    var users = new List<ApplicationUser>();

    //    // Get the list of Users in this Role
    //    foreach (var user in UserManager.Users.ToList())
    //    {
    //      if (await UserManager.IsInRoleAsync(user.Id, role.Name))
    //      {
    //        users.Add(user);
    //      }
    //    }

    //    ViewBag.Users = users;
    //    return View(role);
    //  }

    //  //
    //  // GET: /Roles/Create
    //  [HttpGet]
    //  public ActionResult Create()
    //  {
    //    return View();
    //  }

    //  //
    //  // POST: /Roles/Create
    //  [HttpPost]
    //  [ValidateAntiForgeryToken]
    //  public async Task<ActionResult> Create(RoleViewModel roleViewModel)
    //  {
    //    if (ModelState.IsValid)
    //    {
    //      var roleExists = RoleManager.Roles.Any(r => r.Name == roleViewModel.Name);
    //      if (roleExists == false)
    //      {
    //        var role = new IdentityRole(roleViewModel.Name);
    //        var roleresult = await RoleManager.CreateAsync(role);
    //        if (!roleresult.Succeeded)
    //        {
    //          ModelState.AddModelError("", roleresult.Errors.First());
    //          return View();
    //        }
    //      }
    //      return RedirectToAction("Index");
    //    }
    //    return View();
    //  }

    //  //
    //  // GET: /Roles/Edit/Admin
    //  [HttpGet]
    //  public async Task<ActionResult> Edit(string id)
    //  {
    //    if (id == null)
    //    {
    //      return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //    }
    //    var role = await RoleManager.FindByIdAsync(id);
    //    if (role == null)
    //    {
    //      return HttpNotFound();
    //    }
    //    RoleViewModel roleModel = new RoleViewModel { Id = role.Id, Name = role.Name };
    //    return View(roleModel);
    //  }

    //  [HttpPost]

    //  [ValidateAntiForgeryToken]
    //  public async Task<ActionResult> Edit([Bind(Include = "Name,Id")] RoleViewModel roleModel)
    //  {
    //    if (ModelState.IsValid)
    //    {
    //      var role = await RoleManager.FindByIdAsync(roleModel.Id);
    //      role.Name = roleModel.Name;
    //      await RoleManager.UpdateAsync(role);
    //      return RedirectToAction("Index");
    //    }
    //    return View();
    //  }

    //  //
    //  // GET: /Roles/Delete/5
    //  [HttpGet]
    //  public async Task<ActionResult> Delete(string id)
    //  {
    //    if (id == null)
    //    {
    //      return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //    }
    //    var role = await RoleManager.FindByIdAsync(id);
    //    if (role == null)
    //    {
    //      return HttpNotFound();
    //    }
    //    return View(role);
    //  }

    //  //
    //  // POST: /Roles/Delete/5
    //  [HttpPost]
    //  //[ActionName("Delete")]
    //  [ValidateAntiForgeryToken]
    //  public async Task<ActionResult> Delete(string id, string deleteUser)
    //  {
    //    if (ModelState.IsValid)
    //    {
    //      if (id == null)
    //      {
    //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //      }
    //      var role = await RoleManager.FindByIdAsync(id);
    //      if (role == null)
    //      {
    //        return HttpNotFound();
    //      }
    //      IdentityResult result;
    //      if (deleteUser != null)
    //      {
    //        result = await RoleManager.DeleteAsync(role);
    //      }
    //      else
    //      {
    //        result = await RoleManager.DeleteAsync(role);
    //      }
    //      if (!result.Succeeded)
    //      {
    //        ModelState.AddModelError("", result.Errors.First());
    //        return View();
    //      }
    //      return RedirectToAction("Index");
    //    }
    //    return View();
    //  }
    //
  }
}

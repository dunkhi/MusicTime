using Microsoft.AspNet.Identity;
using MusicTime.Domain.View_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTime.Data
{
  public class UserRepository
  {
    private ApplicationDbContext _context;
    public UserRepository(ApplicationDbContext context)
    {
      _context = context;
    }

    public List<UserIndexViewModel> GetUsers()
    {
      var users = _context.Users.ToList();
      var vmList = new List<UserIndexViewModel>();

      foreach (var user in users)
      {
        var userRoleIds = user.Roles.Select(r => r.RoleId);
        var roles = _context.Roles.Where(r => userRoleIds.Contains(r.Id));
        var rolesJoin = String.Join(", ", roles.Select(r => r.Name).ToList());

        var vm = new UserIndexViewModel()
        {
          Id = user.Id,
          FullName = user.FullName,
          Email = user.Email,
          Username = user.UserName,
          Roles = rolesJoin
        };
        vmList.Add(vm);
      }
      return vmList;
    }
  }
}

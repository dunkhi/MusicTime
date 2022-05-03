using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTime.Data
{
  public class RoleRepository
  {
    public ApplicationDbContext _context = new ApplicationDbContext();

    public RoleRepository(ApplicationDbContext context)
    {
      _context = context;
    }
    public IEnumerable<IdentityRole> GetRoles()
    {
      var roles = _context.Roles.ToList();
      return roles;
    }

    public async Task CreateRole(string name)
    {
      var roles = _context.Roles.ToList();
      if(!roles.Any(r => r.Name == name))
      {
        _context.Roles.Add(new IdentityRole(name));
      }
    }
  }
}

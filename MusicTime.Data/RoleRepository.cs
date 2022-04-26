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

    public List<IdentityRole> GetRoles(ApplicationRoleManager)
    {

    }
  }
}

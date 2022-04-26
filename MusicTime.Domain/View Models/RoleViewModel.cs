using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTime.Domain.View_Models
{
  public class RoleIndexViewModel
  {
    public IdentityRole Role { get; set; }
  }

  public class RoleDetailViewModel
  {
    public IdentityRole Role { get; set; }
    public IEnumerable<ApplicationUser> Users { get; set; }
  }
}

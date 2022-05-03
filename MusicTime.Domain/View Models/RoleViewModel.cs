using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTime.Domain.View_Models
{
  public class RoleIndexViewModel
  {
    public IEnumerable<IdentityRole> Roles { get; set; }
  }

  public class RoleDetailViewModel
  {
    public string Id { get; set; }
    public IdentityRole Role { get; set; }
    public IEnumerable<ApplicationUser> Users { get; set; }
    
  }

  public class RoleEditViewModel
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public IdentityRole Role { get; set; }
    public IEnumerable<ApplicationUser> Users { get; set; }
    public bool RemoveUser { get; set; }
  }
}

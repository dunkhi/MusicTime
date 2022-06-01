using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTime.Domain
{
  public class PersonModel
  {
    [Key]
    public string Name { get; set; }
    public string DateTime { get; set; }
  }
}

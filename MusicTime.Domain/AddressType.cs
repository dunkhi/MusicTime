using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTime.Domain
{
  public class AddressType
  {
    [Key]
    public int Id { get; set; }
    public string Addresstype { get; set; }
  }
}

using MusicTime.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MusicTime.Domain.View_Models
{
  public class AddressTypeViewModel
  {
    public int? CustomerID { get; set; } // Carries the value in POST action.

    [Display(Name = "Address Type")]
    public string SelectedAddressType { get; set; }
    public AddressTypeEnum AddressType { get; set; }
    public IEnumerable<SelectListItem> AddressTypes { get; set; }
  }
}

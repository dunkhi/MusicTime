using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicTime.Web.Extensions
{
  public static class HtmlHelpers
  {
    public static IEnumerable<SelectListItem> ToSelectListItem<T>(this IEnumerable<T> items, Func<T, string> getName,
    Func<T, string> getText, Func<T, string> getValue)
    {
      return
          items.OrderBy(item => getName(item))
          .Select(item =>
                  new SelectListItem
                  {
                    Text = getText(item),
                    Value = getValue(item)
                  });
    }
  }
}

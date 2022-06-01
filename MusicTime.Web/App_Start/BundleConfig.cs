using System.Web;
using System.Web.Optimization;

namespace MusicTime.Web
{
  public class BundleConfig
  {
    // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
    public static void RegisterBundles(BundleCollection bundles)
    {
      bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                  "~/Scripts/jquery-{version}.js")
                  .Include("~/Scripts/typeahead.bundle.js").Include("~/Scripts/jquery-ui.js").Include("~/Scripts/jquery.unobtrusive-ajax.js"))  ;

      bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                  "~/Scripts/jquery.validate*"));

      // Use the development version of Modernizr to develop with and learn from. Then, when you're
      // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
      bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                  "~/Scripts/modernizr-*"));

      bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js"));

      bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/site.css"));

      bundles.Add(new ScriptBundle("~/bundles/App")
                .Include("~/Scripts/App/GetRegions.js")
                .Include("~/Scripts/App/HomeScript.js"));

      bundles.Add(new ScriptBundle("~/bundles/jqueryunobstrusive").Include(
                                    "~/Scripts/jquery.unobstrusive-ajax.js"));

      bundles.Add(new StyleBundle("~/Content/jqueryui").Include("~/Content/jquery-ui.css", "~/Content/jquery-ui.theme.css"));

      bundles.Add(new StyleBundle("~/Content/typeahead").Include("~/Content/typeahead.css"));
    }
  }
}

using MusicTime.Data;
using MusicTime.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicTime.Web.Controllers
{
  public class ExperimentController : Controller
  {
    ApplicationDbContext _context = new ApplicationDbContext();
    // GET: Experiment
    public ActionResult Index()
    {
      return View();
    }

    [HttpPost]
    public JsonResult PostMethod(string name)
    {
      var person = new PersonModel
      {
        Name = $"Send name: {name} from Experiment Controller PostMethod",
        DateTime = DateTime.Now.ToString()
      };
      return Json(person);
    }

    public PartialViewResult GetAlbums()
    {
      var albums = _context.Albums.ToList();
      return PartialView("AllAlbums", albums);
    }

    public JsonResult GetJsonAlbums(string q)
    {
      var albums = _context.Albums.Where(a => a.Title.Contains(q)).ToList();
                           
      
      return Json(albums, JsonRequestBehavior.AllowGet);
    }

    public JsonResult GetJsonArtists(string q)
    {
      var artists = _context.Artists.Where(a => a.FirstName.Contains(q)).ToList();
      return Json(artists, JsonRequestBehavior.AllowGet);
    }

    public ActionResult GetAlbumYears()
    {
      return Json(_context.Albums.Select(x => new
      {
        AlbumId = x.Id,
        AlbumYear = x.Year
      }).ToList(), JsonRequestBehavior.AllowGet);
    }
  }
}

using MusicTime.Data;
using MusicTime.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MusicTime.Web.Controllers
{
  public class BandController : Controller
  {
    // GET: Band
    private BandRepository _bandRepository;
    private MusicTimeContext _context = new MusicTimeContext();

    public BandController()
    {
      _bandRepository = new BandRepository(new MusicTimeContext());
    }

    public ActionResult CssMePlz()
    {
      return View();
    }

    public ActionResult Index()
    {
      return View(_bandRepository.GetBands());
    }

    public ActionResult Search(string searchTerm)
    {
      var band = _bandRepository.SearchBand(searchTerm);
      return View(band);
    }

    public ActionResult Create(int? id)
    {
      return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "Name, BandBio, Genre")] Band band)
    {
      UpdateModel(band);
      if (ModelState.IsValid)
      {
        _bandRepository.CreateBand(band);
        return RedirectToAction("Index");
      }
      return View(band);
    }

    public ActionResult Details(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Band band = _bandRepository.FindBand(id);
      if (band == null)
      {
        return HttpNotFound();
      }
      return View(band);
    }

    public ActionResult Edit(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Band band = _bandRepository.FindBand(id);
      if (band == null)
      {
        return HttpNotFound();
      }
      ViewBag.GenreID = new SelectList(_context.Bands, "id", "Genre", band.id);
      return View(band);
    }

    //[HttpPost]
    //public ActionResult Edit(Band band)
    //{

    //}
  }
}

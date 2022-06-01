using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MusicTime.Data;
using MusicTime.Domain;

namespace MusicTime.Web.Controllers
{
  public class ArtistsController : Controller
  {
    private ApplicationDbContext db = new ApplicationDbContext();
    private ArtistRepository _artistRepository;
    List<Artist> artistsList = new List<Artist>();

    public ArtistsController()
    {
      artistsList = db.Artists.Include(a => a.Band).ToList();
      _artistRepository = new ArtistRepository(new ApplicationDbContext());
    }

    public ActionResult IndexAjax()
    {
      var tuple = new Tuple<List<Artist>, Artist>(artistsList, artistsList[0]);
      return View("Artist", tuple);
    }

    [HttpPost]
    public ActionResult OnSelectArtist(string artistId)
    {
      var tuple = new Tuple<List<Artist>, Artist>(artistsList, artistsList.Where(a => a.Id == Int32.Parse(artistId)).FirstOrDefault());
      var selectedArtist = tuple.Item2;
      var artist = artistsList.Where(a => a.Id == Int32.Parse(artistId)).FirstOrDefault();

      return PartialView("_ArtistDetails", artist);
    }

    // GET: Artists
    public ActionResult Index()
    {
      ViewBag.Instruments = db.Artists.Select(i => i.Instrument).Distinct();
      var artists = db.Artists.Include(a => a.Band).ToList();
      return View(artists.ToList());
    }

    [HttpPost]
    public ActionResult Index(string artistName, int? artistId)
    {
      ViewBag.Message = $"Arist Name: {artistName}, Artist Id: {artistId.ToString()}";
      return View();
    }

    public JsonResult ArtistSearch(string q)
    {
      var result = db.Artists.Where(a => a.FirstName.StartsWith(q)).ToArray();
      var s = Json(result, JsonRequestBehavior.AllowGet);
      return s;
    }

    [HttpPost]
    public JsonResult AutoComplete(string prefix)
    {
      var artists = (from artist in db.Artists
                     where artist.FirstName.StartsWith(prefix)
                     select new
                     {
                       label = artist.FirstName,
                       val = artist.Id
                     }).ToList();
      return Json(artists);
    }

    public ActionResult IndexPartial()
    {
      return PartialView("_ArtistIndex", artistsList);
    }

    

    [HttpPost]
    public ActionResult AjaxDetails(int id)
    {
      var artist = artistsList.Where(a => a.Id == id).FirstOrDefault();
      return PartialView("_ArtistDetails", artist);
    }

    public ActionResult AjaxDetails(int? id)
    {
      var selectedArtist = artistsList.Where(a => a.Id == id).FirstOrDefault();
      return PartialView("_ArtistDetails", selectedArtist);
    }

    // GET: Artists/Details/5
    public ActionResult Details(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Artist artist = db.Artists.Find(id);
      if (artist == null)
      {
        return HttpNotFound();
      }
      return View(artist);
    }

    // GET: Artists/Create
    public ActionResult Create()
    {
      ViewBag.BandId = new SelectList(db.Bands, "id", "Name");
      return View();
    }

    // POST: Artists/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Instrument,Age,ArtistBio,BandId")] Artist artist)
    {
      if (ModelState.IsValid)
      {
        db.Artists.Add(artist);
        db.SaveChanges();
        return RedirectToAction("Index");
      }

      ViewBag.BandId = new SelectList(db.Bands, "id", "Name", artist.BandId);
      return View(artist);
    }

    // GET: Artists/Edit/5
    public ActionResult Edit(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      //Artist artist = db.Artists.Find(id);
      var artist = _artistRepository.GetArtistEvm(id);
      if (artist == null)
      {
        return HttpNotFound();
      }
      //ViewBag.BandId = new SelectList(db.Bands, "id", "Name", artist.BandId);
      return View(artist);
    }

    // POST: Artists/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Instrument,Age,ArtistBio,BandId")] Artist artist)
    {
      if (ModelState.IsValid)
      {
        db.Entry(artist).State = EntityState.Modified;
        db.SaveChanges();
        return RedirectToAction("Index");
      }
      ViewBag.BandId = new SelectList(db.Bands, "id", "Name", artist.BandId);
      return View(artist);
    }

    // GET: Artists/Delete/5
    public ActionResult Delete(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Artist artist = db.Artists.Find(id);
      if (artist == null)
      {
        return HttpNotFound();
      }
      return View(artist);
    }

    // POST: Artists/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
      Artist artist = db.Artists.Find(id);
      db.Artists.Remove(artist);
      db.SaveChanges();
      return RedirectToAction("Index");
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        db.Dispose();
      }
      base.Dispose(disposing);
    }
  }
}

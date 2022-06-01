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
  public class AlbumsController : Controller
  {
    private ApplicationDbContext db = new ApplicationDbContext();

    public ActionResult AjaxSearch(string q)
    {
      var data = GetAlbum(q);
      return PartialView("_AjaxSearch", data);
    }

    public ActionResult AjaxIndex()
    {
      return View();
    }

    public ActionResult AllAlbums()
    {
      return PartialView(db.Albums.ToList());
    }

    public ActionResult AllArtists()
    {
      return PartialView(db.Artists.ToList());
    }

    public List<Album> GetAlbum(string q)
    {
      return db.Albums.Where(a => a.Title.Contains(q)).ToList();
    }

    // GET: Albums
    public ActionResult Index()
    {
      var albums = db.Albums.Include(a => a.Band);
      return View(albums.ToList());
    }

    // GET: Albums/Details/5
    public ActionResult Details(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Album album = db.Albums.Find(id);
      if (album == null)
      {
        return HttpNotFound();
      }
      return View(album);
    }

    // GET: Albums/Create
    public ActionResult Create()
    {
      ViewBag.BandId = new SelectList(db.Bands, "id", "Name");
      return View();
    }

    // POST: Albums/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "Id,BandId,Title,Price,Genre")] Album album)
    {
      if (ModelState.IsValid)
      {
        db.Albums.Add(album);
        db.SaveChanges();
        return RedirectToAction("Index");
      }

      ViewBag.BandId = new SelectList(db.Bands, "id", "Name", album.BandId);
      return View(album);
    }

    // GET: Albums/Edit/5
    public ActionResult Edit(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Album album = db.Albums.Find(id);
      if (album == null)
      {
        return HttpNotFound();
      }
      ViewBag.BandId = new SelectList(db.Bands, "id", "Name", album.BandId);
      return View(album);
    }

    // POST: Albums/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "Id,BandId,Title,Price,Genre")] Album album)
    {
      if (ModelState.IsValid)
      {
        db.Entry(album).State = EntityState.Modified;
        db.SaveChanges();
        return RedirectToAction("Index");
      }
      ViewBag.BandId = new SelectList(db.Bands, "id", "Name", album.BandId);
      return View(album);
    }

    // GET: Albums/Delete/5
    public ActionResult Delete(int? id)
    {
      if (id == null)
      {
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      }
      Album album = db.Albums.Find(id);
      if (album == null)
      {
        return HttpNotFound();
      }
      return View(album);
    }

    // POST: Albums/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
      Album album = db.Albums.Find(id);
      db.Albums.Remove(album);
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

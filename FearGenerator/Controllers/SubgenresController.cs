using Microsoft.AspNetCore.Mvc;
using FearGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FearGenerator.Controllers
{
  public class SubgenresController : Controller
  {
    private readonly FearGeneratorContext _db;
    
    public SubgenresController(FearGeneratorContext db)
    {
      _db = db;
    }
    
    public ActionResult Index()
    {
      List<Subgenre> model = _db.Subgenres.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Subgenre subgenre)
    {
      _db.Subgenres.Add(subgenre);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Subgenre thisSubgenre = _db.Subgenres
        .Include(subgenre => subgenre.JoinEntities)
        .ThenInclude(join => join.Movie)
        .FirstOrDefault(subgenre => subgenre.SubgenreId == id);
      return View(thisSubgenre);
    }

    public ActionResult Search()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Search(string name)
    {
      string searchTerm = name.ToLower();
      List<Subgenre> searchResult = _db.Subgenres.Where(subgenre => subgenre.Name.Contains(searchTerm)).ToList();
      return View("Index", searchResult);
    }

    public ActionResult Edit(int id)
    {
      Subgenre thisSubgenre = _db.Subgenres.FirstOrDefault(subgenre => subgenre.SubgenreId == id);
      ViewBag.MovieId = new SelectList(_db.Movies, "MovieId", "Title");
      return View(thisSubgenre);
    }

    [HttpPost]
    public ActionResult Edit(Subgenre subgenre, int MovieId)
    {
      if (MovieId != 0)
      {
        _db.MoviesSubgenres.Add(new MoviesSubgenres() {MovieId = MovieId, SubgenreId = subgenre.SubgenreId});
      }
      _db.Entry(subgenre).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", new {id = subgenre.SubgenreId});
    }

    public ActionResult Delete(int id)
    {
      Subgenre thisSubgenre = _db.Subgenres.FirstOrDefault(subgenre => subgenre.SubgenreId == id);
      return View(thisSubgenre);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult Destroy(int id)
    {
      Subgenre thisSubgenre = _db.Subgenres.FirstOrDefault(subgenre => subgenre.SubgenreId == id);
      _db.Subgenres.Remove(thisSubgenre);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}

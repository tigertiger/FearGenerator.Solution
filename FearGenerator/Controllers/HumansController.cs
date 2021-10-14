using Microsoft.AspNetCore.Mvc;
using FearGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FearGenerator.Controllers
{
  public class HumansController : Controller
  {
    private readonly FearGeneratorContext _db;

    public HumansController(FearGeneratorContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Human> model = _db.Humans.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      ViewBag.MovieId = new SelectList(_db.Movies, "MovieId", "Title");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Human human, int MovieId)
    {
      _db.Humans.Add(human);
      _db.SaveChanges();
      if(MovieId != 0)
      {
        _db.HumansMovies.Add(new HumansMovies() {MovieId = MovieId, HumanId = human.HumanId});
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Human thisHuman = _db.Humans
      .Include(human => human.HumansJoinEntities)
      .ThenInclude(join => join.Movie)
      .FirstOrDefault(human => human.HumanId == id);
      return View(thisHuman);
    }

    public ActionResult Edit(int id)
    {
      Human thisHuman = _db.Humans.FirstOrDefault(human => human.HumanId == id);
      ViewBag.MovieId = new SelectList(_db.Movies, "MovieId", "Title");
      return View(thisHuman);
    }

    [HttpPost]
    public ActionResult Edit(Human human, int MovieId)
    {
      if (MovieId != 0)
      {
        _db.HumansMovies.Add(new HumansMovies() {MovieId = MovieId, HumanId = human.HumanId});
      }
      _db.Entry(human).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Details", new {id = human.HumanId});
    }
  }
}
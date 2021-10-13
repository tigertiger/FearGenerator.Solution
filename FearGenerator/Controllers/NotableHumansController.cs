using Microsoft.AspNetCore.Mvc;
using FearGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FearGenerator.Controllers
{
  public class NotableHumansController : Controller
  {
    private readonly FearGeneratorContext _db;

    public NotableHumansController(FearGeneratorContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<NotableHuman> model = _db.NotableHuman.ToList();
      return View(model);
    }
  }
}
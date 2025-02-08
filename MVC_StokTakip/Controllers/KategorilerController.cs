using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_StokTakip.Models.Entity;

namespace MVC_StokTakip.Controllers
{
    public class KategorilerController : Controller
    {
        // GET: Kategoriler
        MVC_StokTakipEntities db=new MVC_StokTakipEntities();
        public ActionResult Index()
        {
            return View(db.Kategoriler.ToList());
        }

        public ActionResult Ekle()
        {
            return View();
        }
        public ActionResult Ekle2(Kategoriler p)
        {
            db.Kategoriler.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
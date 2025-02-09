using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_StokTakip.Controllers;

using MVC_StokTakip.Models.Entity;

namespace MVC_StokTakip.Controllers
{
    public class BirimlerController : Controller
    {
        // GET: Birimler
        MVC_StokTakipEntities db = new MVC_StokTakipEntities();
        public ActionResult Index()
        {
            return View(db.Birimler.ToList());
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View("Kaydet");
        }
        [HttpPost]
        public ActionResult Kaydet(Birimler p)
        {
            if (p.ID == 0)
            {
                db.Birimler.Add(p);
            }
            else
            {
                db.Entry(p).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GuncelleBilgiGetir(Birimler p)
        {
            var birimgetir=db.Birimler.Find(p.ID);
            if (birimgetir == null)
            {
                return HttpNotFound();
            }
            return View("Kaydet", birimgetir);
        }
    }
}
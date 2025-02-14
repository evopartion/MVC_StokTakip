using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_StokTakip.Models.Entity;
using MVC_StokTakip.MyModel;

namespace MVC_StokTakip.Controllers
{
    [Authorize(Roles = "A")]
    public class KategorilerController : Controller
    {
        // GET: Kategoriler
        MVC_StokTakipEntities db = new MVC_StokTakipEntities();
        public ActionResult Index()
        {
            return View(db.Kategoriler.ToList());
        }

        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Ekle2(Kategoriler p)
        {
            if (!ModelState.IsValid)
            {
                return View("Ekle");
            }
            db.Kategoriler.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GuncelleBilgiGetir(int id)
        {
            if (ModelState.IsValid)
            {
                return View();
            }
            var model = db.Kategoriler.Find(id);
            //DB'de olmayan ID için işlem yapılırsa çalışacak
            MyKategoriler k = new MyKategoriler();
            k.ID = model.ID;
            k.Kategori = model.Kategori;
            k.Aciklama = model.Aciklama;
            if (model==null)
            {
                return HttpNotFound();
            }
            return View(k);
        }
        public ActionResult Guncelle(Kategoriler p)
        {
            db.Entry(p).State=System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SilBilgiGetir(Kategoriler p)
        {
            var model = db.Kategoriler.Find(p.ID);
            
            if (model==null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
        public ActionResult Sil(Kategoriler p)
        {
            db.Entry(p).State= System.Data.Entity.EntityState.Deleted;
            db.SaveChanges ();
            return RedirectToAction("Index");
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_StokTakip.Controllers;

using MVC_StokTakip.Models.Entity;
using MVC_StokTakip.MyModel;

namespace MVC_StokTakip.Controllers
{
    //Sadece giriş yapanların görmesi için tag helper <3
    [Authorize(Roles = "A")]
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
                if (p.Birim == null || p.Aciklama == null)
                {
                    return View();
                }
                db.Entry(p).State = System.Data.Entity.EntityState.Added;
            }
            else if (p.ID > 0)
            {
                if (true)
                {
                    if (p.Birim == null || p.Aciklama == null)
                    {
                        return View();
                    }
                    db.Entry(p).State = System.Data.Entity.EntityState.Modified;
                }
            }
            
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GuncelleBilgiGetir(int? id)
        {
            var model = db.Birimler.Find(id);
            MyBirimler b = new MyBirimler();
            b.ID = model.ID;
            b.Birim = model.Birim;
            b.Aciklama = model.Aciklama;
            if (model == null)
            {
                return HttpNotFound();
            }
            return View("Kaydet", b);
        }
        public ActionResult SilBilgiGetir(Birimler p)
        {
            var model = db.Birimler.Find(p.ID);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
        public ActionResult Sil(Birimler p)
        {
            db.Entry(p).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
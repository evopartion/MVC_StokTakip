using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_StokTakip.Models.Entity;

namespace MVC_StokTakip.Controllers
{
    public class UrunlerController : Controller
    {
        // GET: Urunler
        MVC_StokTakipEntities db = new MVC_StokTakipEntities();
        public ActionResult Index()
        {
            var model = db.Urunler.ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            var model = new Urunler();
            Yenile(model);
            return View(model);
        }

        private void Yenile(Urunler model)
        {
            List<Kategoriler> kategorilist = db.Kategoriler.OrderBy(x => x.Kategori).ToList();
            model.KategoriListesi = (from x in kategorilist
                                     select new SelectListItem
                                     {
                                         Text = x.Kategori,
                                         Value = x.ID.ToString()
                                     }).ToList();

            List<Birimler> birimlist = db.Birimler.OrderBy(x => x.Birim).ToList();
            model.BirimListesi = (from x in birimlist
                                  select new SelectListItem
                                  {
                                      Text = x.Birim,
                                      Value = x.ID.ToString()
                                  }).ToList();
        }

        [HttpPost]
        public ActionResult Ekle(Urunler p)
        {
            if (!ModelState.IsValid)
            {
                var model = new Urunler();
                Yenile(model);
                return View(model);
            }
            db.Entry(p).State = System.Data.Entity.EntityState.Added;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult MiktarEkle(int id)
        {
            var model = db.Urunler.Find(id);
            return View();
        }
        [HttpPost]
        public ActionResult MiktarEkle(Urunler p)
        {
            var model = db.Urunler.Find(p.ID);
            model.Miktari = model.Miktari + p.Miktari;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public JsonResult GetMarka(int id2)
        {
            var model = new Urunler();
            List<Markalar> markaliste = db.Markalar.Where(x => x.KategoriID == id2).OrderBy(x => x.Marka).ToList();
            model.MarkaListesi = (from x in markaliste
                                  select new SelectListItem
                                  {
                                      Text = x.Marka,
                                      Value = x.ID.ToString()
                                  }).ToList();
            model.MarkaListesi.Insert(0, new SelectListItem { Text = "Seçiniz", Value = "" });
            return Json(model.MarkaListesi, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult GuncelleBilgiGetir(int id)
        {
            var model = db.Urunler.Find(id);
            Yenile(model);
            List<Markalar> markalist = db.Markalar.Where(x => x.KategoriID == model.KategoriID).OrderBy(x => x.Marka).ToList();
            model.MarkaListesi = (from x in markalist
                                  select new SelectListItem
                                  {
                                      Text = x.Marka,
                                      Value = x.ID.ToString()
                                  }).ToList();
            return View(model);
        }
        [HttpPost]
        public ActionResult Guncelle(Urunler p)
        {
            if (!ModelState.IsValid)
            {
                var model = db.Urunler.Find(p.ID);
                Yenile(model);
                List<Markalar> markalist = db.Markalar.Where(x => x.KategoriID == model.KategoriID).OrderBy(x => x.Marka).ToList();
                model.MarkaListesi = (from x in markalist
                                      select new SelectListItem
                                      {
                                          Text = x.Marka,
                                          Value = x.ID.ToString()
                                      }).ToList();
                return View(model);

            }
            db.Entry(p).State=System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using MVC_StokTakip.Models.Entity;
using MVC_StokTakip.MyModel;

namespace MVC_StokTakip.Controllers
{
    [Authorize(Roles = "A")]
    public class MarkalarController : Controller
    {
        // GET: Markalar
        MVC_StokTakipEntities db = new MVC_StokTakipEntities();
        public ActionResult Index()
        {
            var model = db.Markalar.ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            SelecteBilgiGetir();

            return View();
        }
        //ctrl+R+M
        private void SelecteBilgiGetir()
        {
            var model = new MyMarkalar();
            ViewBag.KategoriID = new SelectList(db.Kategoriler, "ID", "Kategori", model.KategoriID);
        }

        [HttpPost]
        public ActionResult Ekle(Markalar m)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.KategoriID = new SelectList(db.Kategoriler, "ID", "Kategori", m.KategoriID);
                return View();
            }
            db.Entry(m).State = System.Data.Entity.EntityState.Added;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GuncelleBilgiGetir(int id)
        {
            MyMarkalar model = new MyMarkalar();
            SelecteBilgiGetir();
            var ara = db.Markalar.Find(id);
            model.ID = ara.ID;
            model.KategoriID = ara.KategoriID;
            model.Aciklama = ara.Aciklama;
            return View(model);
        }

        public ActionResult Guncelle(Markalar p)
        {
            if (!ModelState.IsValid)
            {
                SelecteBilgiGetir();
                return View("GuncelleBilgiGetir");
            }
            db.Entry(p).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SilBilgiGetir(Markalar p)
        {
            var getir = db.Markalar.Find(p.ID);
            return View(getir);
        }
        public ActionResult Sil(Markalar p)
        {
            db.Entry(p).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Urunler(int id)
        {
            var model = db.Urunler.Where(x => x.Markalar.ID == id).ToList();
            var kategori = db.Kategoriler.Where(x => x.ID == id).Select(x => x.Kategori).FirstOrDefault();
            var marka = db.Markalar.Where(x => x.ID == id).Select(x => x.Marka).FirstOrDefault();
            ViewBag.ka = kategori;
            ViewBag.m = marka;
            return View(model);
        }
    }
}
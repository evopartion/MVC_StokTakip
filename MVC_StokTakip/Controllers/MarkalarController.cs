using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using MVC_StokTakip.Models.Entity;

namespace MVC_StokTakip.Controllers
{
    public class MarkalarController : Controller
    {
        // GET: Markalar
        MVC_StokTakipEntities db=new MVC_StokTakipEntities();
        public ActionResult Index()
        {
            var model=db.Markalar.ToList();
            return View(model);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            var model=new Markalar();
            ViewBag.KategoriID = new SelectList(db.Kategoriler, "ID", "Kategori", model.KategoriID);

            return View();
        }
        [HttpPost]
        public ActionResult Ekle(Markalar m)
        {
            return RedirectToAction("Index");
        }
    }
}
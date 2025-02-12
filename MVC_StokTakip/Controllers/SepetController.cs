using MVC_StokTakip.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_StokTakip.Controllers
{
    public class SepetController : Controller
    {
        MVC_StokTakipEntities db= new MVC_StokTakipEntities();
        // GET: Sepet
        public ActionResult Index(decimal? Tutar)
        {
            if (User.Identity.IsAuthenticated)
            {
                var kullaniciAdi = User.Identity.Name;
                var kullanici = db.Kullanicilar.FirstOrDefault(x=>x.KullaniciAdi==kullaniciAdi);
                var model=db.Sepet.Where(x=>x.KullaniciID==kullanici.ID).ToList();
                return View(model);
            }
            return HttpNotFound();
        }
    }
}
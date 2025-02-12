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
                var kid = db.Sepet.FirstOrDefault(x=>x.KullaniciID==kullanici.ID);
                if (model!=null)
                {
                    if (kid==null)
                    {
                        ViewBag.Tutar = "Sepetinizde ürün bulunmuyor";
                    }
                    else if (kid!=null)
                    {
                        Tutar = db.Sepet.Where(x => x.KullaniciID == kid.KullaniciID).Sum(x=>x.ToplamFiyati);
                        ViewBag.Tutar = "Toplam Tutar=" + Tutar + "TL";

                    }
                    return View(model);
                }
                return View(model);
            }
            return HttpNotFound();
        }
    }
}
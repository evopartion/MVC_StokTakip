using MVC_StokTakip.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_StokTakip.Controllers
{
    public class SatislarController : Controller
    {
        // GET: Satislar
        MVC_StokTakipEntities db = new MVC_StokTakipEntities();
        public ActionResult Index()
        {
            var model = db.Satislar.ToList();
            return View(model);
        }
        public ActionResult SatinAl(int id)
        {
            var model = db.Sepet.FirstOrDefault(x => x.ID == id);
            return View(model);
        }
        public ActionResult SatinAl2(int id)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var model = db.Sepet.FirstOrDefault(x => x.ID == id);
                    var urun = db.Urunler.FirstOrDefault(x => x.ID == model.UrunID);
                    urun.Miktari = urun.Miktari - model.Miktari;
                    var satis = new Satislar
                    {
                        KullaniciID = model.KullaniciID,
                        UrunID = model.UrunID,
                        SepetID = model.ID,
                        BarkodNo = model.Urunler.BarkodNo,
                        BirimFiyati = model.BirimFiyati,
                        Miktari = model.Miktari,
                        KDV = model.Urunler.KDV,
                        BirimID = model.Urunler.BirimID,
                        Tarih = DateTime.Now,
                        Saat = DateTime.Now
                    };
                    db.Sepet.Remove(model);
                    db.Satislar.Add(satis);
                    db.SaveChanges();
                    ViewBag.islem = "Satın alma başarılı";
                }
            }
            catch (Exception)
            {
                ViewBag.islem = "Satın alma başarısız";
            }

            return View("islem");
        }

        public ActionResult HepsiniSatinAl(decimal? Tutar)
        {
            if (User.Identity.IsAuthenticated)
            {
                var kullaniciAdi = User.Identity.Name;
                var kullanici = db.Kullanicilar.FirstOrDefault(x => x.KullaniciAdi == kullaniciAdi);
                var model = db.Sepet.Where(x => x.KullaniciID == kullanici.ID).ToList();
                var kid = db.Sepet.FirstOrDefault(x => x.KullaniciID == kullanici.ID);
                if (model != null)
                {
                    if (kid == null)
                    {
                        ViewBag.Tutar = "Sepetinizde ürün bulunmuyor";
                    }
                    else if (kid != null)
                    {
                        Tutar = db.Sepet.Where(x => x.KullaniciID == kid.KullaniciID).Sum(x => x.ToplamFiyati);
                        ViewBag.Tutar = "Toplam Tutar=" + Tutar + "TL";

                    }
                    return View(model);
                }
                return View(model);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult HepsiniSatinAl2()
        {
            var username = User.Identity.Name;
            var kullanici = db.Kullanicilar.FirstOrDefault(x => x.KullaniciAdi == username);
            var model = db.Sepet.Where(x => x.KullaniciID == kullanici.ID).ToList();
            int row = 0;
            foreach (var item in model)
            {
                var satis = new Satislar
                {
                    KullaniciID = model[row].KullaniciID,
                    UrunID = model[row].UrunID,
                    SepetID = model[row].ID,
                    BarkodNo = model[row].Urunler.BarkodNo,
                    BirimFiyati = model[row].BirimFiyati,
                    Miktari = model[row].Miktari,
                    ToplamFiyati = model[row].ToplamFiyati,
                    KDV = model[row].Urunler.KDV,
                    BirimID = model[row].Urunler.BirimID,
                    Tarih = DateTime.Now,
                    Saat = DateTime.Now
                };
                db.Satislar.Add(satis);
                row++;
            }
            foreach (var item in model)
            {
                var urun = db.Urunler.FirstOrDefault(x => x.ID == item.UrunID);
                if (urun != null)
                {
                    urun.Miktari=urun.Miktari-item.Miktari;
                }
            }

            db.Sepet.RemoveRange(model);
            db.SaveChanges();
            return RedirectToAction("Index", "Sepet");
        }
    }
}
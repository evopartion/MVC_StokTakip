using MVC_StokTakip.Models.Entity;
using System;
using System.Collections.Generic;
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
                    var model=db.Sepet.FirstOrDefault(x => x.ID==id);
                    var urun= db.Urunler.FirstOrDefault(x => x.ID==model.UrunID);
                    urun.Miktari=urun.Miktari-model.Miktari;
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
    }
}
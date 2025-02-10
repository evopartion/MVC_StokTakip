using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_StokTakip.Models.Entity;
using System.Web.Security;

namespace MVC_StokTakip.Controllers
{
    [AllowAnonymous]
    public class KullanicilarController : Controller
    {
        MVC_StokTakipEntities db = new MVC_StokTakipEntities();
        // GET: Kullanicilar
        [HttpGet]

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Kullanicilar k)
        {
            var kullanici = db.Kullanicilar.FirstOrDefault(x => x.KullaniciAdi == k.KullaniciAdi && x.Sifre == k.Sifre);
            if (kullanici != null)
            {
                //2. parametre remember me
                FormsAuthentication.SetAuthCookie(k.KullaniciAdi, false);
                return RedirectToAction("Index", "Urunler");
            }
            ViewBag.hata = "Kullanıcı Adı veya Şifre Yanlış";
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}
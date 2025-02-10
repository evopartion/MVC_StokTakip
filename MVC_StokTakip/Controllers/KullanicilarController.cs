using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_StokTakip.Models.Entity;
using System.Web.Security;
using System.Net.Mail;
using System.Net;

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
        [HttpPost]
        public ActionResult ResetPassword(Kullanicilar k)
        {
            var model=db.Kullanicilar.Where(x=>x.Email == k.Email).FirstOrDefault();
            if (model!=null)
            {
                Guid rastgele=Guid.NewGuid();
                model.Sifre = rastgele.ToString().Substring(0, 8);
                db.SaveChanges();
                SmtpClient client=new SmtpClient("smtp.yandex.ru",587);
                client.EnableSsl = true;
                MailMessage mail=new MailMessage();
                mail.From = new MailAddress("gozler.gizler@hotmail.com", "Şifre Sıfırlama");
                mail.To.Add(model.Email);
                mail.IsBodyHtml = true;
                mail.Subject = "Şifre değiştirme isteği";
                mail.Body += "Merhaba" + model.AdiSoyadi + "</br> Kullanıcı Adınız=" + model.KullaniciAdi + "</br> Şifreniz=" + model.Sifre;
                NetworkCredential net = new NetworkCredential("gozler.gizler@hotmail.com", "247dd736");
                client.Credentials = net;
                client.Send(mail);
                return RedirectToAction("Login");
            }
            ViewBag.hata = "Böyle bir mail yok";
            return View();
        }
        [HttpGet]
        public ActionResult ResetPassword()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Kaydol()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Kaydol(Kullanicilar k)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            k.Rol = "U";
            db.Entry(k).State=System.Data.Entity.EntityState.Added;
            db.SaveChanges();
            return RedirectToAction("Login");
        }
    }
}
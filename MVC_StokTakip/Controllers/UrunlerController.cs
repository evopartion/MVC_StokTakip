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
        MVC_StokTakipEntities db=new MVC_StokTakipEntities();
        public ActionResult Index()
        {
            var model=db.Urunler.ToList();
            return View(model);
        }
    }
}
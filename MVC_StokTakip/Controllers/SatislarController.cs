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
        MVC_StokTakipEntities db=new MVC_StokTakipEntities();
        public ActionResult Index()
        {
            var model= db.Satislar.ToList();
            return View(model);
        }
    }
}
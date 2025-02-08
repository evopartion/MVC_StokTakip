using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_StokTakip.Controllers;

using MVC_StokTakip.Models.Entity;

namespace MVC_StokTakip.Controllers
{
    public class BirimlerController : Controller
    {
        // GET: Birimler
        MVC_StokTakipEntities db=new MVC_StokTakipEntities();   
        public ActionResult Index()
        {
            return View(db.Birimler.ToList());
        }
    }
}
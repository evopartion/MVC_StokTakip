﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_StokTakip.Controllers
{
    public class KullanicilarController : Controller
    {
        // GET: Kullanicilar
        public ActionResult Login()
        {
            return View();
        }
    }
}
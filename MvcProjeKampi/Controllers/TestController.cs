﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Test()
        {
            return View();
        }  
        public ActionResult Test1()
        {
            return View();
        }
        public ActionResult SweetAlert()
        {
            return View();
        }
    }
}
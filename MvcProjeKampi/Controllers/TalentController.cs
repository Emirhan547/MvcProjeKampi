using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    [AllowAnonymous]
    public class TalentController : Controller
    {
        // GET: Talent
        TalentManager tm = new TalentManager(new EfTalentDal());
        public ActionResult Index()
        {
            var values = tm.GetList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddTalent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTalent(Talent p)
        {
            tm.TalentAddBl(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditTalent(int id)
        {
            var talent = tm.GetById(id);
            return View(talent);
        }
        [HttpPost]
        public ActionResult EditTalent(Talent p)
        {
            tm.TalentUpdateBl(p);
            return RedirectToAction("Index");
        }
    }
}
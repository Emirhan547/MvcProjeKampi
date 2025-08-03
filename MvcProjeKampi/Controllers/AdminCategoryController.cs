
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FluentValidation.Results;

using ValidationResult = FluentValidation.Results.ValidationResult;


namespace MvcProjeKampi.Controllers
{
    public class AdminCategoryController : Controller
    {

        CategoryManager cm = new CategoryManager(new EfCategoryDal());
        [Authorize(Roles = "A")]
        public ActionResult Index()
        {
            var categoryvalues = cm.GetList();
            return View(categoryvalues);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View(); 
        }

        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
            CategoryValidator categoryvalidator = new CategoryValidator();
            ValidationResult result = categoryvalidator.Validate(p);
            if (result.IsValid)
            {
                cm.CategoryAdd(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(); 
            }

        }
        public ActionResult DeleteCategory(int id)
        {
            var categoryValue = cm.GetById(id);

            if (categoryValue != null)
            {
                cm.CategoryDelete(categoryValue);
            }
            else
            {
                TempData["ErrorMessage"] = "Kategori bulunamadı veya zaten silinmiş.";
                // İstersen hata logla da buraya
            }

            return RedirectToAction("Index");
        }

        [HttpGet]   
        public ActionResult EditCategory(int id)
        { 
            var categoryvalue = cm.GetById(id);
            return View(categoryvalue);
        }
        [HttpPost]
        public ActionResult EditCategory(Category p)
        {
            cm.CategoryUpdate (p);
            return RedirectToAction("Index");
      
        }

    }
}
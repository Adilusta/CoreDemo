using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules.FluentValidation;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using System;
using X.PagedList;
using FluentValidation.Results;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
        public IActionResult Index(int page=1)
        {
            var values = categoryManager.GetListEntity().ToPagedList(page,3);
            // birincisi başlangıç değeri,ikincisi her sayfada kaç tane değer olacak?
            return View(values);
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        } 
        
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
  
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(category);
            if (results.IsValid)
            {
                category.CategoryStatus = true;
                categoryManager.AddEntity(category);
                return RedirectToAction("Index", "Category");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
         [HttpGet("/Admin/Category/DeleteCategory/{categoryID}")]
        public IActionResult DeleteCategory(int categoryID)
        {
            var category = categoryManager.GetEntityByID(categoryID);
            categoryManager.DeleteEntity(category);
            return RedirectToAction("Index");
        }

        [HttpGet("/Admin/Category/EditCategory/{categoryID}")]
        public IActionResult EditCategory(int categoryID)
        {
            var category= categoryManager.GetEntityByID(categoryID);
            return View(category);
        }
        [HttpPost]
        public IActionResult EditCategory(Category category)
        {
            categoryManager.UpdateEntity(category);
            return RedirectToAction("Index");
        }
    }

}

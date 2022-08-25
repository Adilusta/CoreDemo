using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager _categoryManager = new CategoryManager(new EfCategoryRepository());
        public IActionResult GetCategories()
        {
          var values = _categoryManager.GetListEntity();
            return View(values);
        }
    }
}

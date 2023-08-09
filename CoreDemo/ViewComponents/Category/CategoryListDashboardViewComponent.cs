using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreDemo.ViewComponents.Category
{
	public class CategoryListDashboardViewComponent : ViewComponent
	{
        ICategoryService categoryManager = new CategoryManager(new EfCategoryRepository());
        public IViewComponentResult Invoke()
        {
            var categories = categoryManager.GetListEntity();
            return View(categories);
        }
    }
}

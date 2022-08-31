using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Category
{
	public class CategoryListViewComponent : ViewComponent
	{
		ICategoryService categoryManager = new CategoryManager(new EfCategoryRepository());
		public IViewComponentResult Invoke()
		{
			var categories = categoryManager.GetListEntity();
			return View(categories);
		}
	}
}

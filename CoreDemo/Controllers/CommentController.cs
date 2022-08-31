using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
	public class CommentController : Controller
	{
		ICategoryService categoryManager = new CategoryManager(new EfCategoryRepository());
		public IActionResult Index()
		{
			return View();
		}

	}
}

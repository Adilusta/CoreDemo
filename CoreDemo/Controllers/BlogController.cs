using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class BlogController : Controller
    {
        IBlogService blogManager = new BlogManager(new EfBlogRepository());
        public IActionResult Index()
        {
            var result = blogManager.GetListEntity();
            return View(result);
        }
    }
}

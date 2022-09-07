using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        IBlogService blogManager = new BlogManager(new EfBlogRepository());
        public IActionResult Index()
        {
            var result = blogManager.GetBlogsWithCategory();
            return View(result);
        }
        public IActionResult BlogDetails(int id)
        {
            ViewBag.BlogID = id;
            var result = blogManager.GetBlogByBlogID(id);
            return View(result);
        }

    }
}

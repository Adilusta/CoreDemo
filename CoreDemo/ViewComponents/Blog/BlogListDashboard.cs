using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Blog
{
    public class BlogListDashboard : ViewComponent
    {
        IBlogService _blogManager = new BlogManager(new EfBlogRepository());
        public IViewComponentResult Invoke()
        {
            var result = _blogManager.GetBlogsWithCategory();
            return View(result);
        }
    }
}

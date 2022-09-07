using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreDemo.ViewComponents.Blog
{
	public class BlogListByWriterViewComponent : ViewComponent
	{
		IBlogService _blogManager = new BlogManager(new EfBlogRepository());
		public IViewComponentResult Invoke()
		{
			var result = _blogManager.GetBlogsByWriter(1);
			return View(result);
		}
	}
	
}

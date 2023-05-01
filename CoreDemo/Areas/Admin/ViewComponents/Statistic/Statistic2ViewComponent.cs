using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic2ViewComponent : ViewComponent
    {

        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            //ViewBag.vbBlogCount = context.Blogs.Count().ToString();
            //ViewBag.vbContactMessageCount = context.Contacts.Count().ToString();
            //ViewBag.vbCommentCount = context.Comments.Count().ToString();
            ViewBag.lastBlogName = context.Blogs.OrderByDescending(x=> x.BlogId).Select(x=>x.BlogTitle).Take(1).FirstOrDefault() ;
          
            return View();
        }
    }
}

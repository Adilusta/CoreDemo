using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1ViewComponent : ViewComponent
    {
     
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.vbBlogCount = context.Blogs.Count().ToString();
            ViewBag.vbContactMessageCount = context.Contacts.Count().ToString();
            ViewBag.vbCommentCount= context.Comments.Count().ToString();
            return View();
        }
    }
}

using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreDemo.Controllers
{

    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            Context context = new Context();
            var username = User.Identity.Name;
            var userMail = context.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerID= context.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();

          
            ViewBag.toplamBlogSayisi = context.Blogs.Count().ToString();
            ViewBag.yazarBlogSayisi= context.Blogs.Where(p=> p.WriterID== writerID).Count().ToString();
            ViewBag.kategoriSayisi= context.Categories.Count().ToString();
            return View();
        }
    }
}

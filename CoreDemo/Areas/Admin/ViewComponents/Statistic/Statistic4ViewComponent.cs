using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic4ViewComponent : ViewComponent
    {
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.adminName = context.Admins.Where(x=> x.AdminID==1).Select(x => x.Name).FirstOrDefault();
            ViewBag.adminImage = context.Admins.Where(x => x.AdminID == 1).Select(x => x.ImageURL).FirstOrDefault();
            ViewBag.adminDescription = context.Admins.Where(x => x.AdminID == 1).Select(x => x.ShortDescription).FirstOrDefault();
            return View();
        }
    }
}

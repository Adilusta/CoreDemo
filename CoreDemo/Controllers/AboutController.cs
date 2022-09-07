using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class AboutController : Controller
    {
        IAboutService _aboutManager = new AboutManager(new EfAboutRepository());
        public IActionResult Index()
        {
            var result = _aboutManager.GetListEntity();
            return View(result);
        }   
        public PartialViewResult SocialMediaAbout()
        {
         
            return PartialView();
        }
    }
}

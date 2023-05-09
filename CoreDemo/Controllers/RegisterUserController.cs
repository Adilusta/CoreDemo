using CoreDemo.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    [AllowAnonymous]
    public class RegisterUserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterUserController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Index(UserSignUpViewModel p)
        {

            if (ModelState.IsValid)
            {
                //AppUser sınıfımızdan bir nesne türetip parametre olarak gelen nesneyle eşleştiriyoruz..
                AppUser appUser = new AppUser()
                {
                    Email= p.Mail,
                    UserName= p.UserName,
                    NameSurname=p.NameSurname,
                };

                if (!p.IsAcceptTheContract)
                {
                    ModelState.AddModelError("IsAcceptTheContract","Kullanım şartlarını kabul etmeden devam edemezsiniz");
                    return View(p);
                }

                //usermanagerin createasync metoduyla yeni bir user oluşturuyoruz.
                var result = await _userManager.CreateAsync(appUser,p.Password);
                //BAşarılıysa tekrar bizi index sayfasına atacak
                if (result.Succeeded)
                {
                    return RedirectToAction("Index","Login");
                }
                //Başarısızsa gelen hataları bize gösterecek
                else
                {
                    foreach(var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }


            }
            return View(p);
        }
    }
}
